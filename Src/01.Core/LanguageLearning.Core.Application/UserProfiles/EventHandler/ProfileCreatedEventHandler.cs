using LanguageLearning.Core.Application.Common.Abstractions.Notification;
using LanguageLearning.Core.Domain.Framework.Events;
using LanguageLearning.Core.Domain.UserProfiles.Events;

namespace LanguageLearning.Core.Application.UserProfiles.EventHandler;
public class ProfileCreatedEventHandler : IDomainEventHandler<ProfileCreatedEvent>
{
    private readonly IEmailService _emailService;

    public ProfileCreatedEventHandler(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public Task Handle(ProfileCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        return Task.FromResult(0);
    }
}
