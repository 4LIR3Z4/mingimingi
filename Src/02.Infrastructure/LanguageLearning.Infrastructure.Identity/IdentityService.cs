using LanguageLearning.Core.Application.Common.Abstractions.Identity;
using LanguageLearning.Core.Domain.Framework;
using System.Text;
using System.Text.Json;

namespace LanguageLearning.Infrastructure.Security;
public class IdentityService : IIdentityService
{
    private readonly HttpClient _httpClient;

    public IdentityService(HttpClient httpClient)
    {
        _httpClient = httpClient;
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

    public async Task<Result<RegistrationResult>> RegisterAsync(RegistrationRequest request, CancellationToken cancellationToken = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));

        // Prepare payload
        var payload = new
        {
            email = request.Email,
            password = request.Password,
            firstName = request.FirstName,
            lastName = request.LastName
        };

        var content = new StringContent(
            JsonSerializer.Serialize(payload),
            Encoding.UTF8,
            "application/json");
        // POST to the registration endpoint of IdentityServer4 host
        var response = await _httpClient.PostAsync("api/account/register", content);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            return Result.Failure<RegistrationResult>(IdentityErrors.RegistrationFailedError);
        }

        // Parse successful result
        var json = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var dto = JsonSerializer.Deserialize<RegistrationResult>(json, options);

        if (dto == null || string.IsNullOrEmpty(dto.ExternalUserId))
        {

            return Result.Failure<RegistrationResult>(IdentityErrors.InvalidResponseError);
        }

        var result = new RegistrationResult
        {
            ExternalUserId = dto.ExternalUserId
        };

        return Result.Success(result);
    }

    public Task<Result> RevokeRefreshTokenAsync(TokenRevocationRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
