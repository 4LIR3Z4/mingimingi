using Microsoft.Extensions.DependencyInjection;

namespace LanguageLearning.Infrastructure.Notification;

public static class NotificationServiceCollectionExtensions
{
    public static IServiceCollection AddEmailSender(this IServiceCollection services, EmailSenderOptions? emailSenderOptions)
    {

        if (emailSenderOptions is null)
        {
            throw new ArgumentNullException(nameof(emailSenderOptions));
        }
        services.AddFluentEmail(emailSenderOptions.FromAddress).AddSmtpSender(
            host: emailSenderOptions.SmtpServer,
            port: emailSenderOptions.SmtpPort,
            username: emailSenderOptions.SmtpUser,
            password: emailSenderOptions.SmtpPass
        );
        return services;
    }
}
