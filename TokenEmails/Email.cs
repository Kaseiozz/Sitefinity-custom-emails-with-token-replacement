using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using Telerik.Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using Telerik.Sitefinity.Modules.Newsletters;
using Telerik.Sitefinity.Newsletters.Model;
using TokenEmails.Interfaces;

namespace TokenEmails
{
    public class Email
    {
        public string Body
        {
            get;
            set;
        }

        public string FromEmail
        {
            get;
            set;
        }

        public string ReplyAddress
        {
            get;
            set;
        }

        public string Subject
        {
            get;
            set;
        }

        public string ToEmail
        {
            get;
            set;
        }

        public Email()
        {
        }

        public Attachment Attachment { get; set; }
        public string Sender { get; set; }

        public void SendMail()
        {
            var email = new MailMessage()
            {
                From = new MailAddress(this.FromEmail, this.Sender),
                ReplyToList = { new MailAddress(this.ReplyAddress) },
            };
            if (Attachment != null)
            {
                email.Attachments.Add(Attachment);
            };
            email.To.Add(new MailAddress(this.ToEmail));
            email.BodyEncoding = Encoding.UTF8;
            email.Subject = this.Subject;
            email.Body = this.Body;
            email.IsBodyHtml = true;
            (new SmtpClient()).Send(email);
        }

        public void SendSitefinityEmail(ISitefinityEmailTemplate template, IDictionary<EmailTemplateTokens, string> values)
        {
            NewslettersManager manager = NewslettersManager.GetManager();
            MessageBody messageBody = manager.GetMessageBodies().SingleOrDefault(b => b.Name == template.SitefinityMessageTemplate);

            if (messageBody == null) return;

            string content = messageBody.BodyText;

            values.ForEach(v => content = content.Replace(string.Format(@"{{|{0}|}}", v.Key.ToString()), v.Value));

            var email = new MailMessage()
            {
                From = new MailAddress(template.FromEmail, template.Sender),
                ReplyToList = { new MailAddress(template.ReplyAddress) },
            };
            if (Attachment != null)
            {
                email.Attachments.Add(Attachment);
            };
            email.To.Add(new MailAddress(this.ToEmail));
            email.BodyEncoding = Encoding.UTF8;
            email.Subject = template.Subject;
            email.Body = content;
            email.IsBodyHtml = true;
            (new SmtpClient()).Send(email);

        }
    }
}
