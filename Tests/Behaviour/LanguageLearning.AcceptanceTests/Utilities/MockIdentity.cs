using LanguageLearning.Core.Application.Common.Abstractions.Identity;
using LanguageLearning.Core.Domain.Framework;

namespace LanguageLearning.AcceptanceTests.Utilities;
public class MockIdentity : IIdentityService
{
    private readonly bool _authenticationResult;

    public MockIdentity(bool authenticationResult = true) // Constructor to control mock behavior
    {
        _authenticationResult = authenticationResult;
    }

    public Task<Result<UserInfoResult>> GetUserInfoAsync(UserInfoRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Result<AuthenticationResult>> LoginAsync(LoginRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Result<RefreshTokenResult>> RefreshTokenAsync(RefreshTokenRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Result<RegistrationResult>> RegisterAsync(RegistrationRequest request)
    {
        throw new NotImplementedException();
    }
    public Task<Result> RevokeRefreshTokenAsync(TokenRevocationRequest request)
    {
        throw new NotImplementedException();
    }
}
