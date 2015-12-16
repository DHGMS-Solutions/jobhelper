namespace Dhgms.JobHelper.Core.JobNotificationListeners
{
    using System;
    using System.Net.Mail;

    using Dhgms.JobHelper.Core.Helpers;

    using Splat;

    public class EmailJobNotificationListener<TJobResultClass> : IJobNotificationListener<TJobResultClass>, IEnableLogger
    {
        private readonly Func<TJobResultClass, string> _successfulJobResultConvertor;

        private readonly MailAddress _senderEmailAddress;

        private readonly MailAddressCollection _successRecipients;

        private readonly MailAddressCollection _errorRecipients;

        private readonly bool _successEmailIsHtml;

        private readonly string _programName;

        private readonly string _hostName;

        public EmailJobNotificationListener(
            string programName,
            string hostname,
            MailAddress senderEmailAddress,
            MailAddressCollection successRecipients,
            MailAddressCollection errorRecipients,
            Func<TJobResultClass, string> successfulJobResultConvertor,
            bool successEmailIsHtml)
        {
            if (string.IsNullOrWhiteSpace(programName))
            {
                throw new ArgumentNullException("programName");
            }

            if (string.IsNullOrWhiteSpace(hostname))
            {
                throw new ArgumentNullException("hostname");
            }

            if (senderEmailAddress == null)
            {
                throw new ArgumentNullException("senderEmailAddress");
            }

            if (successRecipients == null)
            {
                throw new ArgumentNullException("successRecipients");
            }

            if (errorRecipients == null)
            {
                throw new ArgumentNullException("errorRecipients");
            }

            if (successfulJobResultConvertor == null)
            {
                throw new ArgumentNullException("successfulJobResultConvertor");
            }

            this._programName = programName;
            this._hostName = hostname;
            this._senderEmailAddress = senderEmailAddress;
            this._successRecipients = successRecipients;
            this._errorRecipients = errorRecipients;
            this._successfulJobResultConvertor = successfulJobResultConvertor;
            this._successEmailIsHtml = successEmailIsHtml;
        }

        public void OnJobSucess(Guid guid, string message, TJobResultClass jobResult)
        {
            // get groups of recipients
            // check each groups options
            // get list of recipients for the group
            // generate and send email
            MailAddressCollection bcc = this._errorRecipients;

            string subject = this._programName + ": Completed";
            var convertedJobResultMessage = jobResult != null ? this.GetConvertedJobResultMessage(jobResult) : null;

            this.SendEmail(this._senderEmailAddress, bcc, subject, convertedJobResultMessage, this._successEmailIsHtml);
        }

        public void OnJobFailure(Guid programGuid, string programName, int i, Exception exception)
        {
        }

        private string GetConvertedJobResultMessage(TJobResultClass jobResult)
        {
            try
            {
                return this._successfulJobResultConvertor(jobResult);
            }
            catch (Exception)
            {
                // ignored
            }

            return null;
        }

        private void SendEmail(MailAddress @from, MailAddressCollection bcc, string subject, string body, bool isHtml)
        {
            try
            {
                EmailHelper.SendEmail(this._hostName, from, null, null, bcc, subject, body, null, isHtml);
            }
            catch (Exception exception)
            {
                this.Log().ErrorException("Failed to send email", exception);
            }
        }
    }
}
