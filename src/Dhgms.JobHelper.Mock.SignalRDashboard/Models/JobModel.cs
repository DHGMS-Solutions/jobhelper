using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dhgms.JobHelper.Mock.SignalRDashboard.Models
{
    public class JobModel : IJobModel<int>
    {
        public int JobState { get; set; }

        public string Name { get; set; }
    }
}