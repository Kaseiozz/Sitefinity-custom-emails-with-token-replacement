namespace TokenEmails.Interfaces
{
    public interface ISitefinityEmailTemplate
    {
        string FromEmail { get; }
        string Sender { get; }
        string Subject { get; }
        string ReplyAddress { get; }
        string SitefinityMessageTemplate { get; } //Name of your template created in Sitefinity back end
    }
}
