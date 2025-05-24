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

    public Task<Result<UserInfoResult>> GetUserInfoAsync(UserInfoRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Result<AuthenticationResult>> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Result<RefreshTokenResult>> RefreshTokenAsync(RefreshTokenRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Result<RegistrationResult>> RegisterAsync(RegistrationRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Result> RevokeRefreshTokenAsync(TokenRevocationRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
