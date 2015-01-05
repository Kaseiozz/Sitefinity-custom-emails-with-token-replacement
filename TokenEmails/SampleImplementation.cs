using System.Collections.Generic;
using Telerik.Sitefinity.Security.Model;

namespace TokenEmails
{
    public class SampleImplementation
    {
        private bool SendEmail( User user, string emailAddress)
        {
            var email = new Email();


            string link = "http://google.com";
            // setup values to pass to the template
            var emailContent = new Dictionary<EmailTemplateTokens, string>
            {
                {EmailTemplateTokens.Username, user.UserName},
                {EmailTemplateTokens.Link1, link}
            };

            try
            {
                email.ToEmail = emailAddress;
                email.SendSitefinityEmail(new SampleEmail(), emailContent);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
