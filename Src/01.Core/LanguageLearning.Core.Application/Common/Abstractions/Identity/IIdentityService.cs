namespace LanguageLearning.Core.Application.Common.Abstractions.Identity;
public interface IIdentityService
{
    Task<Result<RegistrationResult>> RegisterAsync(RegistrationRequest request);
    Task<Result<AuthenticationResult>> LoginAsync(LoginRequest request);
    Task<Result<RefreshTokenResult>> RefreshTokenAsync(RefreshTokenRequest request);
    Task<Result> RevokeRefreshTokenAsync(TokenRevocationRequest request);
    Task<Result<UserInfoResult>> GetUserInfoAsync(UserInfoRequest request);

}
