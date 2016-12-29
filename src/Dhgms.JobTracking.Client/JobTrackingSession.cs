using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnsureThat;

namespace Dhgms.JobTracking.Client
{
    internal class JobTrackingSession : IJobTrackingSession//, IDisposable
    {
        private readonly ApiClient _apiClient;
        private readonly Guid _jobSessionGuid;

        public JobTrackingSession(ApiClient apiClient, Guid jobSessionGuid)
        {
            EnsureArg.IsNotNull(apiClient, nameof(apiClient));
            EnsureArg.IsTrue(jobSessionGuid != Guid.Empty, nameof(jobSessionGuid));

            this._apiClient = apiClient;
            this._jobSessionGuid = jobSessionGuid;
        }


        public async Task JobSucceeded()
        {
            await this._apiClient.JobSucceeded(this._jobSessionGuid);
        }

        public async Task JobFailed()
        {
            await this._apiClient.JobFailed(this._jobSessionGuid);
        }

        public async Task JobAmbigious()
        {
            await this._apiClient.JobAmbigious(this._jobSessionGuid);
        }

        public async Task JobStillProcessing()
        {
            await this._apiClient.JobStillProcessing(this._jobSessionGuid);
        }


    }
}
