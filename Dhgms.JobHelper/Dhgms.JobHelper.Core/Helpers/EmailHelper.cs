namespace Dhgms.JobHelper.Core.Helpers
{
    using System;
    using System.Net.Mail;

    using Dhgms.JobHelper.Core.Exceptions;

    public static class EmailHelper
    {
        #region Public Methods and Operators

        /// <summary>
        /// Wrapper for sending an email with a file attachment
        /// </summary>
        /// <param name="hostName">
        /// </param>
        /// <param name="from">
        /// </param>
        /// <param name="to">
        /// </param>
        /// <param name="cc">
        /// </param>
        /// <param name="bcc">
        /// </param>
        /// <param name="subject">
        /// </param>
        /// <param name="body">
        /// </param>
        /// <param name="attachment">
        /// </param>
        /// <param name="isHtml">
        /// Whether the email body is HTML
        /// </param>
        public static void SendEmail(
            string hostName,
            MailAddress from,
            MailAddressCollection to,
            MailAddressCollection cc,
            MailAddressCollection bcc,
            string subject,
            string body,
            Attachment attachment,
            bool isHtml)
        {
            if (from == null)
            {
                throw new ArgumentNullException("from");
            }

            if ((to == null || to.Count == 0) && (cc == null || cc.Count == 0) && (bcc == null || bcc.Count == 0))
            {
                throw new NoEmailRecipientsException();
            }

            MailMessage mail = null;
            try
            {
                mail = new MailMessage();

                mail.From = from;

                mail.To.AddRange(to);
                mail.CC.AddRange(cc);
                mail.Bcc.AddRange(bcc);

                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = isHtml;

                if (attachment != null)
                {
                    mail.Attachments.Add(attachment);
                }

                SendEmail(hostName, mail);
            }
            finally
            {
                if (mail != null)
                {
                    mail.Dispose();
                }
            }
        }

        #endregion

        private static void AddRange(this MailAddressCollection instance, MailAddressCollection sourceCollection)
        {
            if (sourceCollection != null)
            {
                foreach (var item in sourceCollection)
                {
                    instance.Add(item);
                }
            }
        }

        private static void SendEmail(string hostname, MailMessage mail)
        {
            SmtpClient smtpClient = null;

            try
            {
                // ReSharper disable UseObjectOrCollectionInitializer
                smtpClient = new SmtpClient(hostname);
                // ReSharper restore UseObjectOrCollectionInitializer

                // don't use an intialisation list on a disposable type
                // fxcop doesn't like it
                smtpClient.UseDefaultCredentials = true;

                // use windows auth
                smtpClient.Send(mail);
            }
            finally
            {
                if (smtpClient != null)
                {
                    smtpClient.Dispose();
                }
            }
        }
    }
}

