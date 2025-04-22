namespace LanguageLearning.Core.Application.Common.Abstractions.Identity;
public class RegistrationRequest
{
    public string Email { get; init; }
    public string Password { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
}
