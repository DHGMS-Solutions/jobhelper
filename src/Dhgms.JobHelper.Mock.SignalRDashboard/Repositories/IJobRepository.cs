using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using Dhgms.JobHelper.Mock.SignalRDashboard.Models;

namespace Dhgms.JobHelper.Mock.SignalRDashboard.Repositories
{
    public interface IJobRepository
    {
        Task<IEnumerable<TResult>> ListJobs<TResult>(Expression<Func<JobModel, TResult>> selector);
    }
}