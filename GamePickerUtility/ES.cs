using Microsoft.AspNetCore.Identity.UI.Services;

namespace GamePickerUtility;

public class ES: IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        return Task.CompletedTask;
    }
}