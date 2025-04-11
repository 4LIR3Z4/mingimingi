namespace LanguageLearning.Core.Application.Common.Abstractions;
public interface IIdentityService
{
    public Task<Result<bool>> ValidateSSOToken(string token);
}
