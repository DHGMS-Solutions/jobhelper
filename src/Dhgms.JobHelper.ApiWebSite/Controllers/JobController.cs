using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Dhgms.JobHelper.ApiWebSite.Features.Job;

namespace Dhgms.JobHelper.ApiWebSite.Controllers
{
    public class JobController : ApiController
    {
        public async Task<IEnumerable<GetJobResponse>> Get()
        {
            throw new NotImplementedException();
        }
    }
}
