namespace LanguageLearning.Core.Application.Common.Abstractions.Identity;
public class AuthenticationResult
{
    public required string AccessToken { get; init; }
    public required string RefreshToken { get; init; }
    public DateTimeOffset ExpiresAt { get; init; }
}
