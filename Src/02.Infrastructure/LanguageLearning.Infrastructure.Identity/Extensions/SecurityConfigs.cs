using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LanguageLearning.Infrastructure.Security.Extensions;
public static class SecurityConfigs
{
    public static void ConfigureSecurity(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient<IdentityService>();
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder => builder
                 .AllowAnyOrigin()
                 .AllowAnyMethod()
            .AllowAnyHeader());
        });


        string secretKey = configuration["JWT:Secret"] ?? "";//Environment.GetEnvironmentVariable("Secret");
        string tokenDecryptionKey = configuration["JWT:Secret2"] ?? "";
        string validUser = configuration["JWT:ValidIssuer"] ?? "";
        string validAudience = configuration["JWT:ValidAudience"] ?? "";
        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer(opt =>
        {
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = validUser,
                ValidAudience = validAudience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                TokenDecryptionKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenDecryptionKey)),
                ClockSkew = TimeSpan.FromSeconds(15)
            };
        });
        services.AddAuthorization();
    }
}
