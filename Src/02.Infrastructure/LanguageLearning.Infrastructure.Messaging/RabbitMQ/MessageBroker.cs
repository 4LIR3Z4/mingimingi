using LanguageLearning.Core.Application.Common.Abstractions.Messaging;
using LanguageLearning.Infrastructure.Messaging.Extensions;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
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

    public async Task PublishMessageAsync<T>(T message, string exchangeName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await _channel.ExchangeDeclareAsync(exchange: exchangeName, type: ExchangeType.Fanout, durable: true, cancellationToken: cancellationToken);


        var body = JsonSerializer.SerializeToUtf8Bytes(message);

        await _channel.BasicPublishAsync(exchangeName, string.Empty, body, cancellationToken);

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
    public async Task<string> SubscribeToQueueAsync<T>(string exchangeName, Func<T, Task> handler, CancellationToken cancellationToken)
    {
        await _channel.ExchangeDeclareAsync(exchange: exchangeName, type: ExchangeType.Fanout, durable: true, cancellationToken: cancellationToken);

        QueueDeclareOk queueDeclareResult = await _channel.QueueDeclareAsync();
        string queueName = queueDeclareResult.QueueName;


        await _channel.QueueBindAsync(queue: queueName, exchange: exchangeName, routingKey: string.Empty);
        var consumer = new AsyncEventingBasicConsumer(_channel);
        string message = string.Empty;
        consumer.ReceivedAsync += (model, ea) =>
        {
            cancellationToken.ThrowIfCancellationRequested();
            var body = ea.Body.ToArray();
            message = Encoding.UTF8.GetString(body);
            var deserializedMessage = JsonSerializer.Deserialize<T>(message);
            if (deserializedMessage is not null)
                return handler(deserializedMessage);

            return Task.CompletedTask;
        };

        await _channel.BasicConsumeAsync(queueName, autoAck: true, consumer: consumer);


        return await Task.FromResult(string.Empty);

    }
}
