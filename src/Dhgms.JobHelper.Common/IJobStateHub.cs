using System.Collections.Generic;
using System.Threading.Tasks;
using Dhgms.JobHelper.Common.Responses;

namespace Dhgms.JobHelper.Common
{
    public interface IJobStateHub
    {
        Task<IEnumerable<JobStateResponse>> ListJobs();
    }
}