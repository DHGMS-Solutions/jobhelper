using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dhgms.JobHelper.ApiWebSite.Features.JobSession
{
    public class GetJobSessionResponse
    {
        public Guid JobSessionGuid { get; set; }

        public Guid JobGuid { get; set; }

        public DateTime StartedUtc { get; set; }

        public DateTime? FinishedUtc { get; set; }
    }
}