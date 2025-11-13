using LanguageLearning.Core.Application.Common.Abstractions.Identity;
using LanguageLearning.Core.Application.Common.Abstractions.Notification;
using LanguageLearning.Core.Domain.Framework.Events;
using LanguageLearning.Core.Domain.LearningJourneys.Events;

namespace LanguageLearning.Core.Application.LearningJourneys.EventHandler;
public sealed class LearningPathAddedEventHandler : IDomainEventHandler<LearningPathAddedEvent>
{
    private readonly IDbContext _dbContext;
    private readonly IEmailService _emailService;
    private readonly IIdentityService _identityService;

    public LearningPathAddedEventHandler(IDbContext dbContext, IEmailService emailService, IIdentityService identityService)
    {
        _dbContext = dbContext;
        _emailService = emailService;
        _identityService = identityService;
    }

    public async Task Handle(LearningPathAddedEvent domainEvent, CancellationToken cancellationToken)
    {
        // Get the journey
        var journey = await _dbContext.LearningJourneys
            .AsNoTracking()
            .FirstOrDefaultAsync(j => j.Id == domainEvent.JourneyId, cancellationToken);
        if (journey is null)
            return;

        // Get the user profile
        var userProfile = await _dbContext.UserProfiles
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.IdentityUserId == journey.UserId.ToString(), cancellationToken);
        if (userProfile is null)
            return;

        // Get the user's email from identity service
        var userInfoResult = await _identityService.GetUserInfoAsync(new UserInfoRequest() { UserId = userProfile.IdentityUserId }, cancellationToken);
        if (userInfoResult.IsFailure)
            return;
        var email = userInfoResult.Value.Email;

        // Send notification email
        var subject = "A new learning path has been added!";
        var body = $"Dear {userProfile.FirstName}, a new learning path has been added to your journey.";
        await _emailService.SendEmailAsync(email, subject, body, true, cancellationToken);
    }
}
