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
        private readonly Expression<Func<JobModel, string>> _jobSelectorExpression;

        private JobStateTicker(IHubConnectionContext<IJobHubClient> clients, IJobRepository backingJobRepository)
        {
            this._clients = clients;
            this._backingJobRepository = backingJobRepository;

            // TODO: expand this into proper model
            this._jobSelectorExpression = model => model.Name;
        }

        public async Task<IEnumerable<string>> ListJobs()
        {
            return await this._backingJobRepository.ListJobs(this._jobSelectorExpression);
        }

        private void BroadCastJobState(JobModel jobModel)
        {
            this._clients.All.OnJobUpdated(jobModel);
        }
    }
}