using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;
using Dhgms.JobHelper.Mock.SignalRDashboard.Repositories;
using EnsureThat;
using JetBrains.Annotations;

namespace Dhgms.JobHelper.Mock.SignalRDashboard.Hubs
{
    [HubName("JobStateHub")]
    public class JobHub : Hub
    {
        private readonly IJobRepository _jobRepository;

        public JobHub([NotNull]IJobRepository jobRepository)
        {
            EnsureArg.IsNotNull(jobRepository, nameof(jobRepository));

            this._jobRepository = jobRepository;
        }

        public async Task<IEnumerable<Models.JobModel>> ListJobs()
        {
            return await this._jobRepository.ListJobs<Models.JobModel>(null);
        }
    }
}