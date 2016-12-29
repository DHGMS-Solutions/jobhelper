using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dhgms.JobHelper.Mock.SignalRDashboard.Models
{
    interface IJobModel<TJobState>
    {
        string Name { get; set; }

        TJobState JobState { get; set; }
    }
}
