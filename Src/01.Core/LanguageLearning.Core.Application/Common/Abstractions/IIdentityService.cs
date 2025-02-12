namespace LanguageLearning.Core.Application.Common.Abstractions;
public interface IIdentityService
{
    Task<Result<bool>> ValidateSSOToken(string token);
}
