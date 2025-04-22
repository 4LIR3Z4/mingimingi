namespace LanguageLearning.Core.Application.Common.Abstractions.Identity;
public class AuthenticationResult
{
    public string AccessToken { get; init; }
    public string RefreshToken { get; init; }
    public DateTimeOffset ExpiresAt { get; init; }
}
