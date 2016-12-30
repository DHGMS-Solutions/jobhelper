using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dhgms.JobHelper.Common.Responses;

namespace Dhgms.JobHelper.Mock.SignalRDashboard
{
    public interface IJobStateTicker
    {
        Task<IEnumerable<JobStateResponse>> ListJobs();
    }
}
