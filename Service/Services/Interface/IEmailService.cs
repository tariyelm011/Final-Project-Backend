namespace Service.Services.Interface;

public interface IEmailService
{
    void SendEmail(string toEmail, string subject, string emailBody);
}
