namespace LanguageLearning.Core.Application.Common.Abstractions.Messaging;
public interface IMessageBroker
{
    public Task PublishMessageAsync<T>(T message, QueueName queue, CancellationToken cancellationToken);
    public Task<string> SubscribeToQueueAsync<T>(QueueName queue, Func<T, Task> handler, CancellationToken cancellationToken);
}
