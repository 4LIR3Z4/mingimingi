namespace LanguageLearning.Core.Application.Common.Abstractions.Messaging;
public interface IMessageBroker
{
    public Task PublishMessageAsync<T>(T message, Queue queue, CancellationToken cancellationToken);
    public Task SubscribeToQueueAsync<T>(Queue queue, Func<T, Task> handler, CancellationToken cancellationToken);
}
