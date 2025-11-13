using FluentEmail.Core;
using LanguageLearning.Core.Application.Common.Abstractions.Notification;

namespace LanguageLearning.Infrastructure.Notification;

public class EmailService : IEmailService
{
    private IFluentEmail _fluentEmail;
    public EmailService(IFluentEmail fluentEmail)
    {

        _fluentEmail = fluentEmail;
    }

    public async Task SendEmailAsync(string to, string subject, string body, bool isHtml = true, CancellationToken cancellationToken = default)
    {
        await _fluentEmail
            .To(to)
            .Subject(subject)
            .Body(body, isHtml).SendAsync(cancellationToken);

    }
}
