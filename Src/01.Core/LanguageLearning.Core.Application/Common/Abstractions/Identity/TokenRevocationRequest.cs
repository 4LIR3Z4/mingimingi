namespace LanguageLearning.Core.Application.Common.Abstractions.Identity;
public class TokenRevocationRequest
{
    public required string RefreshToken { get; init; }

}
