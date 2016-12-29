using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dhgms.JobHelper.Mock.SignalRDashboard.Models;

namespace Dhgms.JobHelper.Mock.SignalRDashboard
{
    public interface IJobHubClient
    {
        void OnJobUpdated(JobModel jobModel);

        void OnJobDeleted(int jobId);
    }
}
