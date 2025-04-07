namespace LanguageLearning.Core.Application.Common.Framework.MediatorWrappers;

public interface ICommandHandler<TCommand> 
    where TCommand : ICommand
{
}

public interface ICommandHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    Task<Result<TResponse>> Handle(TCommand command, CancellationToken cancellationToken);
}