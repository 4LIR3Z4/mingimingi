using LanguageLearning.Core.Domain.UserProfiles.Constants;
using LanguageLearning.Core.Domain.UserProfiles.Enums;

namespace LanguageLearning.Core.Application.UserProfiles.Commands;
public sealed class CreateUserProfileCommandValidator : AbstractValidator<CreateUserProfileCommand>
{
    public CreateUserProfileCommandValidator()
    {
        RuleFor(x => x.request.FirstName)
            .NotEmpty()
            .WithMessage("FirstName is required")
            .MaximumLength(UserProfileConstant.FirstNameMaxLength)
            .WithMessage($"First name cannot exceed {UserProfileConstant.FirstNameMaxLength} characters")
            .Matches("^[a-zA-Z]+$")
            .WithMessage("FirstName must contain only alphabetic characters");


        RuleFor(x => x.request.LastName)
            .NotEmpty()
            .WithMessage("LastName is required")
            .MaximumLength(UserProfileConstant.LastNameMaxLength)
            .WithMessage($"Last name cannot exceed {UserProfileConstant.LastNameMaxLength} characters")
            .Matches("^[a-zA-Z]+$")
            .WithMessage("LastName must contain only alphabetic characters");


        // Age validation
        RuleFor(x => x.request.Age)
            .GreaterThan(UserProfileConstant.AgeMinValue)
            .WithMessage($"Age must be greater than {UserProfileConstant.AgeMinValue}")
            .LessThanOrEqualTo(UserProfileConstant.AgeMaxValue)
            .WithMessage($"Age must not exceed {UserProfileConstant.AgeMaxValue}");


        RuleFor(x => x.request.Gender)
            .Must(value => Enum.IsDefined(typeof(GenderType), value))
            .WithMessage("Gender must be one of the predefined values");


        RuleFor(x => x.request.NativeLanguage)
            .GreaterThan(0)
            .WithMessage("Native language ID must be greater than 0");


        // NativeLanguage validation
        RuleFor(x => x.request.NativeLanguage)
            .GreaterThan(0).WithMessage("Native language ID must be greater than 0");

        // CountryOfOrigin validation
        RuleFor(x => x.request.CountryOfOrigin)
            .GreaterThan(0).WithMessage("Country of origin ID must be greater than 0");

        // CurrentCountry validation
        RuleFor(x => x.request.CurrentCountry)
            .GreaterThan(0).WithMessage("Current country ID must be greater than 0");

        // Hobbies validation
        RuleFor(x => x.request.Hobbies)
            .NotNull()
            .WithMessage("Hobbies are required")
            .Must(hobbies => hobbies.Count > 0)
            .WithMessage("At least one hobby must be provided")
            .ForEach(hobby => hobby.GreaterThan(0)
            .WithMessage("Each hobby ID must be greater than 0"));


        // Interests validation
        RuleFor(x => x.request.Interests)
            .NotNull()
            .WithMessage("Interests are required")
            .Must(interests => interests.Count > 0)
            .WithMessage("At least one interest must be provided")
            .ForEach(interest => interest.GreaterThan(0)
            .WithMessage("Each interest ID must be greater than 0")); ;
    }
}
