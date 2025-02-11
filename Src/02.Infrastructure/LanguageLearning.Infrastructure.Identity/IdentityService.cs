using LanguageLearning.Core.Application.Common.Abstractions;
using Microsoft.Extensions.Configuration;
namespace LanguageLearning.Infrastructure.Security;
public class IdentityService(IConfiguration configuration) : IIdentityService
{
    private readonly IConfiguration _configuration = configuration;

   
}
