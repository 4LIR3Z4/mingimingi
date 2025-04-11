namespace LanguageLearning.Core.Application.UserProfiles.Commands;
public sealed class CreateUserProfileCommandValidator : AbstractValidator<CreateUserProfileCommand>
{
    public CreateUserProfileCommandValidator()
    {
        RuleFor(x => x.request.FirstName)
            .NotEmpty().WithMessage("First name is required")
            .MaximumLength(50).WithMessage("First name cannot exceed 50 characters");

        RuleFor(x => x.request.LastName)
            .NotEmpty().WithMessage("Last name is required")
            .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters");

        //RuleFor(x => x.request.Birthdate)
        //    .NotEmpty().WithMessage("Birthdate is required")
        //    .LessThan(DateTime.UtcNow).WithMessage("Birthdate cannot be in the future")
        //    .Must(date => date.Year >= 1900).WithMessage("Birthdate must be after 1900");

        RuleFor(x => x.request.Gender)
            .IsInEnum().WithMessage("Invalid gender value");

        //RuleFor(x => x.request.NativeLanguageId)
        //    .GreaterThan(0).WithMessage("Native language ID must be greater than 0");

        //RuleFor(x => x.request.CountryOfOriginId)
        //    .GreaterThan(0).WithMessage("Country of origin ID must be greater than 0")
        //    .MustAsync(async (id, cancellation) =>
        //        await countryRepository.ExistsAsync(id))
        //    .WithMessage("Country of origin does not exist");

        //RuleFor(x => x.request.CurrentCountryId)
        //    .GreaterThan(0).WithMessage("Current country ID must be greater than 0")
        //    .MustAsync(async (id, cancellation) =>
        //        await countryRepository.ExistsAsync(id))
        //    .WithMessage("Current country does not exist");

        //RuleFor(x => x.request.HobbyIds)
        //    .NotNull().WithMessage("Hobbies cannot be null")
        //    .MustAsync(async (ids, cancellation) =>
        //        await hobbyRepository.AllExistAsync(ids))
        //    .WithMessage("One or more hobbies do not exist")
        //    .When(x => x.HobbyIds.Any());

        //RuleFor(x => x.request.InterestIds)
        //    .NotNull().WithMessage("Interests cannot be null")
        //    .MustAsync(async (ids, cancellation) =>
        //        await interestRepository.AllExistAsync(ids))
        //    .WithMessage("One or more interests do not exist")
        //    .When(x => x.InterestIds.Any());
    }
}
