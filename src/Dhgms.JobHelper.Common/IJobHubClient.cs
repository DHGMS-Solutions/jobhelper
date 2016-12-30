using Dhgms.JobHelper.Common.Responses;

namespace Dhgms.JobHelper.Common
{
    public interface IJobHubClient
    {
        void OnJobUpdated(JobStateResponse jobStateResponse);

        void OnJobDeleted(int jobId);
    }
}