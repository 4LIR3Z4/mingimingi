namespace LanguageLearning.Core.Application.Common.Abstractions.Identity;
public class UserInfoResult
{
    public required string ExternalUserId { get; init; }
    public required string Email { get; init; }
    public required string Name { get; init; }
}
