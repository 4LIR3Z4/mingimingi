namespace LanguageLearning.Core.Application.Common.Abstractions;
public interface IIdentityService
{
    public Task<string> RegisterUserAsync(string email, string password, string externalUserId);
    public Task<Result<bool>> ValidateUserAsync(string email, string password);
}
