using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using Dhgms.JobHelper.Mock.SignalRDashboard.Models;
using Dhgms.JobHelper.Mock.SignalRDashboard.Repositories;

namespace Dhgms.JobHelper.Mock.SignalRDashboard
{
    public class InMemoryJobRepository : IJobRepository
    {
        private readonly List<JobModel> _jobs = new List<JobModel>
        {
            new JobModel
            {
                ExecutionState =0,
                Id = 1,
                Name = "Job 1",
                ServiceLevelAgreementState = 0
            }
        };

        public async Task<IEnumerable<TResult>> ListJobs<TResult>(Expression<Func<JobModel, TResult>> selector)
        {
            return await Task.FromResult(_jobs.AsQueryable().Select(selector));
        }
    }
}