using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;
using Dhgms.JobHelper.Mock.SignalRDashboard.Repositories;
using Dhgms.JobHelper.Mock.SignalRDashboard.Responses;
using EnsureThat;
using JetBrains.Annotations;
using Splat;

namespace Dhgms.JobHelper.Mock.SignalRDashboard.Hubs
{
    [HubName("jobStateHub")]
    public class JobHub : Hub<IJobHubClient>, IEnableLogger
    {
        private readonly IJobStateTicker _jobStateTicker;

        public JobHub([NotNull]IJobStateTicker jobStateTicker)
        {
            EnsureArg.IsNotNull(jobStateTicker, nameof(jobStateTicker));

            this._jobStateTicker = jobStateTicker;
        }

        public async Task<IEnumerable<JobStateResponse>> ListJobs()
        {
            return await this._jobStateTicker.ListJobs();
        }
    }
}