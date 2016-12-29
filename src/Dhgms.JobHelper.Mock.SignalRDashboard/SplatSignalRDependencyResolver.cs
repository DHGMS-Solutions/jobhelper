namespace Dhgms.JobHelper.Mock.SignalRDashboard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Microsoft.AspNet.SignalR;

    public class SplatSignalRDependencyResolver : DefaultDependencyResolver
    {
        public override object GetService(Type serviceType)
        {
            return Splat.Locator.Current.GetService(serviceType);
        }

        public override IEnumerable<object> GetServices(Type serviceType)
        {
            return Splat.Locator.Current.GetServices(serviceType);
        }
    }
}