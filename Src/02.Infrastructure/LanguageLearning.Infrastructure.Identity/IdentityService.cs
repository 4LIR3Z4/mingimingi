using LanguageLearning.Core.Application.Common.Abstractions;
using LanguageLearning.Core.Domain.Framework;

namespace LanguageLearning.Infrastructure.Security;
public class IdentityService() : IIdentityService
{

    public Task<string> RegisterUserAsync(string email, string password, string externalUserId)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<bool>> ValidateUserAsync(string email, string password)
    {
        await Task.FromResult(0);
        throw new NotImplementedException();
    }
}
