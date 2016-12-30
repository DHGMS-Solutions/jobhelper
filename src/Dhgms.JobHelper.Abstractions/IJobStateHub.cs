using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dhgms.JobHelper.Abstractions
{
    public interface IJobStateHub
    {
        Task<IEnumerable<JobStateResponse>> ListJobs();
    }
}