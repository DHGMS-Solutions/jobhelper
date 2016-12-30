using Dhgms.JobHelper.Mock.SignalRDashboard.Responses;
using EnsureThat;

namespace Dhgms.JobHelper.Mock.SignalRDashboard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using System.Web;
    using Dhgms.JobHelper.Mock.SignalRDashboard.Hubs;
    using Dhgms.JobHelper.Mock.SignalRDashboard.Models;
    using Dhgms.JobHelper.Mock.SignalRDashboard.Repositories;
    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;

    public sealed class JobStateTicker : IJobStateTicker
    {
        private readonly IHubConnectionContext<IJobHubClient> _clients;
        private readonly IJobRepository _backingJobRepository;

        public JobStateTicker(IHubConnectionContext<IJobHubClient> clients, IJobRepository backingJobRepository)
        {
            EnsureArg.IsNotNull(clients, nameof(clients));
            EnsureArg.IsNotNull(backingJobRepository, nameof(backingJobRepository));

            this._clients = clients;
            this._backingJobRepository = backingJobRepository;
        }

        public async Task<IEnumerable<JobStateResponse>> ListJobs()
        {
            return await this._backingJobRepository.ListJobs(GetJobStateResponseSelector());
        }

        private void BroadcastJobState(JobModel jobModel)
        {
            this._clients.All.OnJobUpdated(jobModel);
        }

        private static Expression<Func<JobModel, JobStateResponse>> GetJobStateResponseSelector()
        {
            return model => new JobStateResponse { Id = model.Id, Name = model.Name };
        }
    }
}