namespace LanguageLearning.Core.Application.LearningJourneys.Commands.CreateLearningPath;

internal sealed class CreateLearningPathCommandValidator : AbstractValidator<CreateLearningPathCommand>
{
    public CreateLearningPathCommandValidator()
    {
        RuleFor(x => x.Message)
            .NotNull().WithMessage("Journey message is required");

        RuleFor(x => x.Message.JourneyId)
            .GreaterThan(0).WithMessage("JourneyId must be greater than 0");

        RuleFor(x => x.Message.CreatedAt)
            .NotEqual(default(DateTimeOffset)).WithMessage("CreatedAt must be a valid date");
    }
}
