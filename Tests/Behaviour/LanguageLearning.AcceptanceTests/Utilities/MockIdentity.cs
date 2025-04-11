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

    public async Task<Result<bool>> ValidateSSOToken(string token)
    {
        if (_authenticationResult)
            return await Task.FromResult(Result.Success<bool>(true));

        return await Task.FromResult(Result.Failure<bool>(new Error("", "")));
    }
}
