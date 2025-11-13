namespace LanguageLearning.Core.Application.Common.Abstractions.Identity;
public class RegistrationRequest
{
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
}
