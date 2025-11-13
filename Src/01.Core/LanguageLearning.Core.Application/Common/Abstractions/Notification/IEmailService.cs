namespace LanguageLearning.Core.Application.Common.Abstractions.Notification;
public interface IEmailService
{
    Task SendEmailAsync(string to, string subject, string body, bool isHtml = true, CancellationToken cancellationToken = default);
}
