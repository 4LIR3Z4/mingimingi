using System.Diagnostics;

namespace LanguageLearning.Core.Application.Common.Behaviors;
public class PerformanceBehavior<TRequest, TResponse>(
   
        //ICurrentUserService currentUserService,
        //IIdentityService identityService
        ) : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
{
    private readonly Stopwatch _timer = new();

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _timer.Start();

        var response = await next();

        _timer.Stop();

        var elapsedMilliseconds = _timer.ElapsedMilliseconds;

        if (elapsedMilliseconds > 100)
        {
            var requestName = typeof(TRequest).Name;

        }

        return response;
    }


}