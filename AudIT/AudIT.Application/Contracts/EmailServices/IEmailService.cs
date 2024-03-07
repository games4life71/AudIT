namespace AudIT.Applicationa.Contracts.EmailServices;

/// <summary>
/// This interface is responsible for sending emails to users.
/// </summary>
public interface IEmailService
{
    public Task<(string, bool)> SendEmailAsync(string recipient, string subject, string htmlMessage);
}