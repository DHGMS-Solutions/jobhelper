using System.Diagnostics;
using Dhgms.JobHelper.Mock.SignalRDashboard.Hubs;
using Microsoft.AspNet.SignalR;
using Owin;

namespace Dhgms.JobHelper.Mock.SignalRDashboard.Configuration
{
    public class OwinConfiguration
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var resolver = new SplatSignalRDependencyResolver();
            GlobalHost.DependencyResolver = resolver;
            var serviceLocatorConfiguration = ServiceLocatorConfiguration.Instance;
            Debug.Assert(serviceLocatorConfiguration != null, "serviceLocatorConfiguration != null");

            var hubConfiguration = new HubConfiguration
            {
                Resolver = resolver
            };

            appBuilder.MapSignalR(hubConfiguration);
        }
    }
}