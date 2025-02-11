using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace LanguageLearning.Presentation.API.Framework;
public class ExceptionHandler(
    IProblemDetailsService problemDetailsService,
    ILogger<ExceptionHandler> logger,
    IHostEnvironment environment) :
    Microsoft.AspNetCore.Diagnostics.IExceptionHandler
{
    private readonly IProblemDetailsService _problemDetailsService = problemDetailsService;
    private readonly ILogger<ExceptionHandler> _logger = logger;
    private readonly IHostEnvironment _hostEnvironment = environment;

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        string title = "An error occurred";
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        string message = _hostEnvironment.IsDevelopment() ? exception.Message : string.Empty;
        var extensions = new Dictionary<string, object?>();
        if (exception is ValidationException validationException)
        {
            List<string> validationErrors = new List<string>();
            foreach (var error in validationException.Errors)
            {
                validationErrors.Add(error.ErrorMessage);
            }
            extensions.Add("errors", validationErrors);
            httpContext.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
            title = "one or more validation errors occurred.";
            //message = validationException.Message;
        }

        _logger.LogError("Method : {Method} Path : {Path} Query :{Query} " +
            "Headers : {Headers} " +
            "Ip : {Ip} " +
            "Error :{Error} " +
            "Body :{Body}",
            httpContext.Request.Method,
            httpContext.Request.Path,
            httpContext.Request.QueryString.ToString(),
            httpContext.Request.Headers,
            httpContext.Connection.RemoteIpAddress is null ? httpContext.Request.Host.Host : httpContext.Connection.RemoteIpAddress,
            exception.Message,
            await GetRequestBodyAsText(httpContext)
            );

        var WriteToResponseResult = await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext
        {
            HttpContext = httpContext,
            ProblemDetails =
                {
                    Title = title,
                    Detail = message,
                    Type = exception.GetType().Name,
                    Extensions = extensions,
                    Status = httpContext.Response.StatusCode
                },
            Exception = exception
        });
        if (WriteToResponseResult == false)
        {
            extensions.TryAdd("TraceIdentifier", httpContext.TraceIdentifier);
            var problemDetails = new ProblemDetails
            {
                Status = httpContext.Response.StatusCode,
                Type = exception.GetType().Name,
                Title = title,
                Detail = message,
                Extensions = extensions,
                Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
            };
            await httpContext
                .Response
                .WriteAsJsonAsync(problemDetails, cancellationToken);

        }
        return await ValueTask.FromResult(true);

    }
    private async Task<string> GetRequestBodyAsText(HttpContext httpContext)
    {
        // Ensure the body can be read multiple times (for example, for logging)
        httpContext.Request.EnableBuffering();

        // Read the request body
        using (StreamReader reader = new StreamReader(httpContext.Request.Body, leaveOpen: true))
        {
            string bodyAsString = await reader.ReadToEndAsync();

            // Reset the stream position to allow re-reading later
            httpContext.Request.Body.Position = 0;

            // Deserialize the request body to a JsonDocument
            return bodyAsString;
        }
    }
}