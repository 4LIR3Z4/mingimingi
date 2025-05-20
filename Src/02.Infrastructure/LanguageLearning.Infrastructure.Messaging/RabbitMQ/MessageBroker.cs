using LanguageLearning.Core.Application.Common.Abstractions.Messaging;
using LanguageLearning.Infrastructure.Messaging.Extensions;
using RabbitMQ.Client;
using System.Text.Json;

namespace LanguageLearning.Infrastructure.Messaging.RabbitMQ;
public sealed class MessageBroker : IMessageBroker
{
    private IConnection _connection;
    private IChannel _channel;
    private MessageBrokerSettings _settings;

    public MessageBroker(IConnection connection, IChannel channel, MessageBrokerSettings settings)
    {
        _connection = connection;
        _channel = channel;
        _settings = settings;
    }

    public async Task PublishMessageAsync<T>(T message, string exchangeName, string routingKey, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await _channel.ExchangeDeclareAsync(exchange: exchangeName, type: ExchangeType.Fanout, durable: true, cancellationToken: cancellationToken);


        var body = JsonSerializer.SerializeToUtf8Bytes(message);

        await _channel.BasicPublishAsync(exchangeName, routingKey, body, cancellationToken);

        await Task.CompletedTask;
    }
    public static async Task<MessageBroker> InitializeAsync(MessageBrokerSettings settings, CancellationToken cancellationToken = default)
    {
        var factory = new ConnectionFactory
        {
            HostName = settings.HostName,
            Port = settings.Port,
            VirtualHost = settings.VirtualHost,
            UserName = settings.UserName,
            Password = settings.Password
        };

        var connection = await factory.CreateConnectionAsync(cancellationToken);
        var channel = await connection.CreateChannelAsync(cancellationToken: cancellationToken);
        return new MessageBroker(connection, channel, settings);
    }
    public async Task<string> SubscribeToQueueAsync<T>(string queueName, Func<T, Task> handler)
    {

        throw new Exception("");

    }
}
