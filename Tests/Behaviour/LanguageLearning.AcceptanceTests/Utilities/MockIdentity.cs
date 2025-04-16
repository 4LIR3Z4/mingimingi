using LanguageLearning.Core.Application.Common.Abstractions;
using LanguageLearning.Core.Domain.Framework;

namespace LanguageLearning.AcceptanceTests.Utilities;
public class MockIdentity : IIdentityService
{
    private readonly bool _authenticationResult;

    public MockIdentity(bool authenticationResult = true) // Constructor to control mock behavior
    {
        _authenticationResult = authenticationResult;
    }

    public Task<string> RegisterUserAsync(string email, string password, string externalUserId)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<bool>> ValidateUserAsync(string email, string password)
    {
        if (_authenticationResult)
            return await Task.FromResult(Result.Success<bool>(true));

        return await Task.FromResult(Result.Failure<bool>(new Error("", "")));
    }
}
