using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using Dhgms.JobHelper.Common;
using Dhgms.JobHelper.Common.Responses;
using Dhgms.JobHelper.Sample.Wpf.Features.MainWindow;
using Microsoft.AspNet.SignalR.Client;

namespace Dhgms.JobHelper.Sample.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnLoadCompleted(NavigationEventArgs e)
        {
            base.OnLoadCompleted(e);

            var viewModel = InitViewModel();
        }

        private MainViewModel InitViewModel()
        {
            var url = "http://localhost/signalr";
            var hubConnection = new HubConnection(url);
            const string hubName = "JobStateHub";
            var hubProxy = hubConnection.CreateObservableHubProxy<IJobStateHub, IJobHubClient>(hubName);
            //hubProxy.SubscribeOn<JobStateResponse>(client => client.OnJobUpdated, x => x.Id);

            return new MainViewModel();
        }
    }
}
