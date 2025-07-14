using LanguageLearning.Core.Application.Common.Abstractions.Notification;
using Microsoft.Extensions.DependencyInjection;

namespace LanguageLearning.Core.Application.Common.Framework.MediatorWrappers.Commands;
public interface ICommandDispatcher
{
    Task<Result<TResponse>> DispatchAsync<TCommand, TResponse>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : ICommand<TResponse>;
}
public sealed class CommandDispatcher : ICommandDispatcher
{
    private readonly IServiceScopeFactory _scopeFactory;
    public CommandDispatcher(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task<Result<TResponse>> DispatchAsync<TCommand, TResponse>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : ICommand<TResponse>
    {
        using var scope = _scopeFactory.CreateScope();
        var validators = scope.ServiceProvider.GetServices<IValidator<TCommand>>();
        if (validators.Any())
        {
            var context = new ValidationContext<TCommand>(command);
            var validationResults = await Task.WhenAll(
                validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            var failures = validationResults
                .SelectMany(r => r.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Count > 0)
            {
                throw new ValidationException(failures);
            }
        }
        var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand, TResponse>>();
        return await handler.Handle(command, cancellationToken);
    }
}