using LanguageLearning.Core.Application.Common.Abstractions;
using LanguageLearning.Core.Domain.Framework;
using Microsoft.Extensions.Configuration;

namespace LanguageLearning.Infrastructure.Security;
public class IdentityService(IConfiguration configuration) : IIdentityService
{
    private readonly IConfiguration _configuration = configuration;

    public async Task<Result<bool>> ValidateSSOToken(string token)
    {
        await Task.FromResult(0);
        throw new NotImplementedException();
    }
}
