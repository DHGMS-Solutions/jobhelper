using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dhgms.JobHelper.Mock.SignalRDashboard
{
    public interface IJobStateTicker
    {
        Task<IEnumerable<string>> ListJobs();
    }
}
