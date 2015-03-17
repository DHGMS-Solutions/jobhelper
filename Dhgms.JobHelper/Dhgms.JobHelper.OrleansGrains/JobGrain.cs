namespace Dhgms.JobHelper.OrleansGrains
{
    using Orleans;

    using System.Threading.Tasks;

    using Dhgms.JobHelper.Core;
    using Dhgms.JobHelper.OrleansGrainInterfaces;

    /// <summary>
    /// Grain implementation class for wrapping the Job base class.
    /// </summary>
    public abstract class JobGrain<TJob, TApplicationSettings, TJobResult> : Grain, IJobGrain<TJobResult>
        where TJob : IJob<TApplicationSettings, TJobResult>
        where TApplicationSettings : IApplicationConfiguration
    {
        public async Task<TJobResult> Execute()
        {
            var job = this.GetJob();
            var settings = this.GetSettings();
            return await job.Execute(settings);
        }

        protected abstract TApplicationSettings GetSettings();

        protected abstract TJob GetJob();
    }
}
