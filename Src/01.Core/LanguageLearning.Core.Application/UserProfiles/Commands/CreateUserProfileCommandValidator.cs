namespace LanguageLearning.Core.Application.UserProfiles.Commands;
public sealed class CreateUserProfileCommandValidator : AbstractValidator<CreateUserProfileCommand>
{
    public CreateUserProfileCommandValidator()
    {
        RuleFor(v => v.request.FirstName)
            .MaximumLength(200)
            .NotEmpty();
    }
}
