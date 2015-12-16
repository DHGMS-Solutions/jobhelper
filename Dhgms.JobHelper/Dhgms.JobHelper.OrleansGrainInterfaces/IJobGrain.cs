using Orleans;

namespace Dhgms.JobHelper.OrleansGrainInterfaces
{
    using System.Threading.Tasks;

    /// <summary>
    /// Grain interface IGrain1
    /// </summary>
    public interface IJobGrain<TJobResult> : IGrain
    {
        Task<TJobResult> Execute();
    }
}
