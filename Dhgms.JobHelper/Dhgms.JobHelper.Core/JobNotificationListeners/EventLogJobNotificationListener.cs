namespace Dhgms.JobHelper.Core.JobNotificationListeners
{
    using System;
    using System.Diagnostics;

    public class EventLogJobNotificationListener<TJobResultClass> : IJobNotificationListener<TJobResultClass>
    {
        public void OnJobSucess(Guid guid, string message, TJobResultClass jobResult)
        {
            EventLog.WriteEntry(guid.ToString(), message, EventLogEntryType.Information);
        }

        public void OnJobFailure(Guid programGuid, string programName, int i, Exception exception)
        {
            EventLog.WriteEntry(programGuid.ToString(), exception.ToString(), EventLogEntryType.Error);
        }
    }
}
