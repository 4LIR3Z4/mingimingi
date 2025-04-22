namespace LanguageLearning.Core.Application.Common.Abstractions.Identity;
public class UserInfoResult
{
    
    public string ExternalUserId { get; init; }

    /// <summary>
    /// You can map back only the claims you actually use for business logic,
    /// e.g. 
    /// </summary>
    public string Email { get; init; }
    public string GivenName { get; init; }
    public string FamilyName { get; init; }
}
