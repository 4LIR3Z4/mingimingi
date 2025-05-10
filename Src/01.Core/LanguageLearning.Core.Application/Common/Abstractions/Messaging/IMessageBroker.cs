namespace LanguageLearning.Core.Application.Common.Abstractions.Messaging;
public interface IMessageBroker
{
    public Task Publish<T>(T message, string exchangeName, string routingKey, CancellationToken cancellationToken);
    public Task<string> Subscribe<T>(string queueName, Func<T, Task> handler);
}
