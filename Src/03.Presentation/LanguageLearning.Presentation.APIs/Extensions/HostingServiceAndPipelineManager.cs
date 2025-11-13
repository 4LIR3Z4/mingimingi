using LanguageLearning.Core.Application.Common.Extensions;
using LanguageLearning.Infrastructure.Caching.Extensions;
using LanguageLearning.Infrastructure.HealthChecks.Extensions;
using LanguageLearning.Infrastructure.IdGenerator.Extensions;
using LanguageLearning.Infrastructure.Messaging.Extensions;
using LanguageLearning.Infrastructure.Notification;
using LanguageLearning.Infrastructure.Observability.Extensions;
using LanguageLearning.Infrastructure.Persistence.Extensions;
using LanguageLearning.Infrastructure.Security.Extensions;
using LanguageLearning.Infrastructure.Services.Extensions;
using LanguageLearning.Presentation.API.Framework;
using LanguageLearning.Presentation.API.ServiceCollectionManager;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Models;
using Serilog;
namespace LanguageLearning.Presentation.API.Extensions;

public static class HostingServiceAndPipelineManager
{
    public static WebApplication ConfigureService(this WebApplicationBuilder builder)
    {

        builder.Services.InitApplication();
        builder.Services.AddExceptionHandler<ExceptionHandler>();
        builder.Services.ConfigDbContext(builder.Configuration);
        builder.Services.ConfigureSecurity(builder.Configuration);
        builder.Services.ConfigureHttpClients();
        builder.Services.ConfigureCaching();
        
        var messageBrokerSettings = builder.Configuration.GetSection("MessageBrokerSettings").Get<MessageBrokerSettings>();
        builder.Services.RegisterMessageBroker(messageBrokerSettings);
        builder.Services.RegisterSnowflakeIdGeneratorService(1);

        var emailSenderSettings = builder.Configuration.GetSection("MessageBrokerSettings").Get<EmailSenderOptions>();

        builder.Services.AddEmailSender(emailSenderSettings);

        builder.Services.AddControllers();
        builder.Services.AddOpenApi(options =>
        {
            //options.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
            options.AddDocumentTransformer((document, context, cancellationToken) =>
            {
                document.Info.Contact = new OpenApiContact
                {
                    Name = "Contoso Support",
                    Email = "support@contoso.com"
                };

                document.Info.Title = "مستندات سرویس بانکداری شرکتی";
                document.Info.Description = "مستندات سرویس بانکداری شرکتی";
                return Task.CompletedTask;
            });

        });

        builder.ConfigureOpenTelemetry();
        
        builder.Services.ConfigureHealthChecks(builder.Configuration);
        builder.Services.AddProblemDetails(options =>
            options.CustomizeProblemDetails = ctx =>
            {
                ctx.ProblemDetails.Instance = $"{ctx.HttpContext.Request.Method} {ctx.HttpContext.Request.Path}";
                ctx.ProblemDetails.Extensions.TryAdd("TraceIdentifier", ctx.HttpContext.TraceIdentifier);
            });
        builder.Host.UseSerilog((hostContext, services, config) =>
        {
            config.ReadFrom.Configuration(hostContext.Configuration);
        });
        builder.Services.RegisterInfraServices(builder.Configuration);
        return builder.Build();
    }

    internal sealed class BearerSecuritySchemeTransformer(IAuthenticationSchemeProvider authenticationSchemeProvider) : IOpenApiDocumentTransformer
    {
        public async Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context, CancellationToken cancellationToken)
        {
            var authenticationSchemes = await authenticationSchemeProvider.GetAllSchemesAsync();
            if (authenticationSchemes.Any(authScheme => authScheme.Name == "Bearer"))
            {
                var requirements = new Dictionary<string, OpenApiSecurityScheme>
                {
                    ["Bearer"] = new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "bearer", // "bearer" refers to the header name here
                        In = ParameterLocation.Header,
                        BearerFormat = "Json Web Token"
                    }
                };
                document.Components ??= new OpenApiComponents();
                document.Components.SecuritySchemes = requirements;
            }
        }
    }
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            //app.UseDeveloperExceptionPage();
            app.MapHealthChecks("/health");
        }
        app.UseExceptionHandler();
        app.UseSerilogRequestLogging();
        app.UseStatusCodePages();

        app.UseHttpsRedirection();
        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.All
        });
        app.UseCors("CorsPolicy");
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        return app;
    }


}
