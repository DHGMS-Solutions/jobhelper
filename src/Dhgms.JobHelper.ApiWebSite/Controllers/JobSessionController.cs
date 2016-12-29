using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Dhgms.JobHelper.ApiWebSite.Features.JobSession;

namespace Dhgms.JobHelper.ApiWebSite.Controllers
{
    public class JobSessionController : ApiController
    {
        //[Route("/api/jobsession/{jobSessionGuid}")]
        public async Task<GetJobSessionResponse> Get(Guid jobSessionGuid)
        {
            throw new NotImplementedException();

        }

        //[Route("/api/jobsession")]
        public async Task<IEnumerable<GetJobSessionResponse>> List()
        {
            throw new NotImplementedException();
        }

        [Route("/api/job/{jobGuid}/session")]
        public async Task<IEnumerable<GetJobSessionResponse>> ListByJobGuid(Guid jobGuid)
        {
            throw new NotImplementedException();

        }

        public async Task<AddJobSessionResponse> Post(AddJobSessionRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
