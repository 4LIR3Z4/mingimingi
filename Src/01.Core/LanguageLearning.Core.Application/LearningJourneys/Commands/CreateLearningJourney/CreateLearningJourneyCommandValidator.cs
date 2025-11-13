namespace LanguageLearning.Core.Application.LearningJourneys.Commands.CreateLearningJourney;

internal sealed class CreateLearningJourneyCommandValidator : AbstractValidator<CreateLearningJourneyCommand>
{
    public CreateLearningJourneyCommandValidator()
    {
        RuleFor(x => x.request)
            .NotNull().WithMessage("Request is required");

        RuleFor(x => x.request.TargetLanguageId)
            .GreaterThan(0).WithMessage("TargetLanguageId must be greater than 0");

        RuleFor(x => x.request.LearningTarget)
            .IsInEnum().WithMessage("LearningTarget must be a valid enum value");

        RuleFor(x => x.request.PracticePerDayInMinutes)
            .GreaterThan(0).WithMessage("PracticePerDayInMinutes must be greater than 0");

        RuleFor(x => x.request.ReadingProficiency)
            .IsInEnum().WithMessage("ReadingProficiency must be a valid enum value");
        RuleFor(x => x.request.WritingProficiency)
            .IsInEnum().WithMessage("WritingProficiency must be a valid enum value");
        RuleFor(x => x.request.ListeningProficiency)
            .IsInEnum().WithMessage("ListeningProficiency must be a valid enum value");
        RuleFor(x => x.request.SpeakingProficiency)
            .IsInEnum().WithMessage("SpeakingProficiency must be a valid enum value");
    }
}
