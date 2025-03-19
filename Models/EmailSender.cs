using DailyBalance1._0.Models;
using Microsoft.AspNetCore.Identity;

public class EmailSender : IEmailSender<ApplicationUser>
{
    public Task SendConfirmationLinkAsync(ApplicationUser user, string email, string token)
    {
        return Task.CompletedTask; // No-op implementation
    }

    public Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string token)
    {
        return Task.CompletedTask;
    }

    public Task SendEmailAsync(ApplicationUser user, string email, string subject, string htmlMessage)
    {
        return Task.CompletedTask;
    }

    public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode)
    {
        throw new NotImplementedException();
    }
}
