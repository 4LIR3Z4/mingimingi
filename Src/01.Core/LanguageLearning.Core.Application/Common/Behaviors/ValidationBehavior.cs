namespace LanguageLearning.Core.Application.Common.Behaviors;
public class ValidationBehavior<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    private readonly IEnumerable<IValidator<TCommand>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TCommand>> validators)
    {
        _validators = validators;
    }

    public async Task<Result<TResponse>> HandleWithValidation(
        TCommand command,
        Func<TCommand, CancellationToken, Task<Result<TResponse>>> next,
        CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TCommand>(command);
            var validationResults = await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(context, cancellationToken))
            );

            var failures = validationResults
                .SelectMany(r => r.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Count != 0)
                throw new ValidationException(failures);
        }

        return await next(command, cancellationToken);
    }
}
