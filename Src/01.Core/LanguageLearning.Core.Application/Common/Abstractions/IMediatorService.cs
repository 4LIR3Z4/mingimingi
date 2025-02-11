namespace LanguageLearning.Core.Application.Common.Abstractions;
public interface IMediatorService
{
    Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
}
public class MediatorService : IMediatorService
{
    readonly ISender _sender;

    public MediatorService(ISender sender)
    {
        _sender = sender;
    }

    public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        return _sender.Send(request, cancellationToken);
    }
}