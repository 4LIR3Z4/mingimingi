namespace LanguageLearning.Core.Application.Common.Abstractions.Messaging;
public interface IMessageBroker
{
    public Task PublishMessageAsync<T>(T message, string exchangeName, string routingKey, CancellationToken cancellationToken);
    public Task<string> SubscribeToQueueAsync<T>(string queueName, Func<T, Task> handler);
}
