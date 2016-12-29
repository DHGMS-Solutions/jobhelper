using Microsoft.AspNet.SignalR;
using Owin;

namespace Dhgms.JobHelper.Mock.SignalRDashboard.Configuration
{
    public static class Configuration
    {
        public static void Configure(IAppBuilder appBuilder)
        {
            var hubConfiguration = new HubConfiguration
            {
                Resolver = new SplatSignalRDependencyResolver()
            };

            appBuilder.MapSignalR(hubConfiguration);
        }
    }
}