namespace SendEmailsWithAspDotNetCore.Models
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
