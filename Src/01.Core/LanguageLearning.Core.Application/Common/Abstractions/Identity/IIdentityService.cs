namespace LanguageLearning.Core.Application.Common.Abstractions.Identity;
public interface IIdentityService
{
    Task<Result<RegistrationResult>> RegisterAsync(RegistrationRequest request, CancellationToken cancellationToken = default);
    Task<Result<AuthenticationResult>> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);
    Task<Result<RefreshTokenResult>> RefreshTokenAsync(RefreshTokenRequest request, CancellationToken cancellationToken = default);
    Task<Result> RevokeRefreshTokenAsync(TokenRevocationRequest request, CancellationToken cancellationToken = default);
    Task<Result<UserInfoResult>> GetUserInfoAsync(UserInfoRequest request, CancellationToken cancellationToken = default);

}
