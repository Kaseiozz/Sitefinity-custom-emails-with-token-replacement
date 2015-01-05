using TokenEmails.Interfaces;

namespace TokenEmails
{
    //Sample implementation.
    public class SampleEmail : ISitefinityEmailTemplate
    {
        public string FromEmail
        {
            get { return "email@email.com"; }
        }
        public string Sender {
            get { return "My Company"; }
        }
        public string Subject
        {
            get { return "Message subject"; }
        }
        public string ReplyAddress
        {
            get { return "noreply@email.com"; }
        }
        public string SitefinityMessageTemplate
        {
            get { return "SampleMessage"; }
        }
    }
}
