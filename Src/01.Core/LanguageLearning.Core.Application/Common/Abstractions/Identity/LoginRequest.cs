namespace LanguageLearning.Core.Application.Common.Abstractions.Identity;
public class LoginRequest
{
    public required string Username { get; init; }
    public required string Password { get; init; }
}
