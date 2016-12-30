using System;
using System.Diagnostics;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;

namespace Dhgms.JobHelper.Mock.SignalRDashboard.Configuration
{
    using Dhgms.JobHelper.Mock.SignalRDashboard.Hubs;
    using Dhgms.JobHelper.Mock.SignalRDashboard.Repositories;
    using Splat;

    internal sealed class ServiceLocatorConfiguration
    {
        private static readonly Lazy<ServiceLocatorConfiguration> _lazyInstance = new Lazy<ServiceLocatorConfiguration>(() =>
        {
            var newInstance = new ServiceLocatorConfiguration();
            return newInstance;
        });

        public static ServiceLocatorConfiguration Instance => _lazyInstance.Value;

        static ServiceLocatorConfiguration()
        {
            var mutatableDependencyResolver = Splat.Locator.CurrentMutable;

            RegisterJobHub(mutatableDependencyResolver);
        }

        private static void RegisterJobHub(IMutableDependencyResolver mutatableDependencyResolver)
        {
            mutatableDependencyResolver.RegisterConstant(new InMemoryJobRepository(), typeof(IJobRepository));
            mutatableDependencyResolver.RegisterLazySingleton(GetJobStateTickerFactory());
            mutatableDependencyResolver.Register(GetJobHubFactory());
        }

        private static Func<JobHub> GetJobHubFactory()
        {
            return () =>
            {
                // resolution done via dependency resolver as showing how a different dll \ subsystem could be used for registering\resolution
                var jobStateTicker =
                    GlobalHost.DependencyResolver.GetService(typeof(IJobStateTicker)) as IJobStateTicker;
                Debug.Assert(jobStateTicker != null, "jobStateTicker != null");
                return new JobHub(jobStateTicker);
            };
        }

        private static Func<IJobStateTicker> GetJobStateTickerFactory()
        {
            return () =>
            {
                // resolution done via dependency resolver as showing how a different dll \ subsystem could be used for registering\resolution
                var dependencyResolver = GlobalHost.DependencyResolver;
                var connectionManager = dependencyResolver.GetService(typeof(IConnectionManager)) as IConnectionManager;
                Debug.Assert(connectionManager != null, "connectionManager != null");
                var hubContext = connectionManager.GetHubContext<JobHub, IJobHubClient>();
                var clients = hubContext.Clients;

                var backingJobRepository = dependencyResolver.GetService(typeof(IJobRepository)) as IJobRepository;
                return new JobStateTicker(clients, backingJobRepository);
            };
        }
    }
}