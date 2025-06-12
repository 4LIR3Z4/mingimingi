namespace LanguageLearning.Core.Application.Common.Abstractions.Messaging;
public interface IMessageBroker
{
    public Task PublishMessageAsync<T>(T message, string exchangeName, CancellationToken cancellationToken);
    public Task<string> SubscribeToQueueAsync<T>(string exchangeName, Func<T, Task> handler, CancellationToken cancellationToken);
}
