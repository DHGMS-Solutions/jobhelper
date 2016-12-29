using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnsureThat;

namespace Dhgms.JobTracking.Client
{
    public interface IJobTrackingService : IStartSubJobTracking
    {
        Task<Guid> StartJobTrackingSession(int jobId);

        //Task OnStillProcessing(Guid jobStillProcessing);
    }

    public interface IReportJobStateService
    {
        Task OnSucceeded(Guid jobSessionId);

        Task OnFailed(Guid jobSessionId);

        Task OnAmbigious(Guid jobSessionId);
    }

    public interface IStartSubJobTracking
    {
        //Task<ISubJobTrackingService> StartSubJobTrackingSession(Guid subjobId);
    }

    public interface ISubJobTrackingService
    {
    }

    public sealed class ApiClient : IJobTrackingService
    {
        private Uri _baseUri;

        public ApiClient(Uri baseUri)
        {
            EnsureArg.IsNotNull(baseUri, nameof(baseUri));
            var schemes = new[]{"http", "https"};
            EnsureArg.IsTrue(baseUri.IsAbsoluteUri && schemes.Any(s => s.Equals(baseUri.Scheme, StringComparison.OrdinalIgnoreCase)), nameof(baseUri));

            this._baseUri = baseUri;
        }

        public Task<Guid> StartJobTrackingSession(int jobId)
        {
            throw new NotImplementedException();
        }

        public Task JobSucceeded(Guid jobSessionId)
        {
            throw new NotImplementedException();
        }

        public Task JobFailed(Guid jobSessionId)
        {
            throw new NotImplementedException();
        }

        public Task JobAmbigious(Guid jobSessionId)
        {
            throw new NotImplementedException();
        }

        public Task JobStillProcessing(Guid jobStillProcessing)
        {
            throw new NotImplementedException();
        }
    }
}
