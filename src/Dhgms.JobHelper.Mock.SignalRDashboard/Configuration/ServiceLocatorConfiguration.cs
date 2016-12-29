namespace Dhgms.JobHelper.Mock.SignalRDashboard.Configuration
{
    using Dhgms.JobHelper.Mock.SignalRDashboard.Hubs;
    using Dhgms.JobHelper.Mock.SignalRDashboard.Repositories;
    using Splat;

    internal sealed class ServiceLocatorConfiguration
    {
        internal void Configure()
        {
            var dependencyResolver = Splat.Locator.Current;
            var mutatableDependencyResolver = Splat.Locator.CurrentMutable;

            RegisterJobHub(dependencyResolver, mutatableDependencyResolver);
        }

        private static void RegisterJobHub(IDependencyResolver dependencyResolver, IMutableDependencyResolver mutatableDependencyResolver)
        {
            var jobStateTicker = dependencyResolver.GetService<IJobStateTicker>();
            var jobHub = new JobHub(jobStateTicker);
            mutatableDependencyResolver.RegisterConstant(jobHub);
        }
    }
}