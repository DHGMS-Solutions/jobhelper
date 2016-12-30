using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Dhgms.JobHelper.Sample.Wpf.Features.ViewJobState
{
    public class JobStateViewModel : ReactiveObject, IJobStateViewModel
    {
        private int _id;
        private string _name;

        public int Id
        {
            get { return _id; }
            set { this.RaiseAndSetIfChanged(ref _id, value); }
        }

        public string Name
        {
            get { return _name; }
            set { this.RaiseAndSetIfChanged(ref _name, value); }
        }
    }
}
