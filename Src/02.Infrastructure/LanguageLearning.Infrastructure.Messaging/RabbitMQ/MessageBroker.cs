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
    private const string ExchangeName = "MainExchange";
    
    public MessageBroker(IConnection connection, IChannel channel, MessageBrokerSettings settings)
    {
        _connection = connection;
        _channel = channel;
        _settings = settings;
    }

    public async Task PublishMessageAsync<T>(T message, QueueName queue, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await _channel.ExchangeDeclareAsync(exchange: ExchangeName, type: ExchangeType.Fanout, durable: true, cancellationToken: cancellationToken);


        var body = JsonSerializer.SerializeToUtf8Bytes(message);

        await _channel.BasicPublishAsync(ExchangeName, string.Empty, body, cancellationToken);

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
        await channel.ExchangeDeclareAsync(exchange: ExchangeName, type: ExchangeType.Fanout, durable: true, cancellationToken: cancellationToken);
        foreach (var queue in Enum.GetValues(typeof(QueueName)).Cast<QueueName>())
        {
            QueueDeclareOk queueDeclareResult = await channel.QueueDeclareAsync(queue: queue.ToString(), durable: true, exclusive: false, autoDelete: false, cancellationToken: cancellationToken);
            await channel.QueueBindAsync(queue: queue.ToString(), exchange: ExchangeName, routingKey: string.Empty, cancellationToken: cancellationToken);
        }       
        return new MessageBroker(connection, channel, settings);
    }
    public async Task<string> SubscribeToQueueAsync<T>(QueueName queue, Func<T, Task> handler, CancellationToken cancellationToken)
    {
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

        await _channel.BasicConsumeAsync(queue.ToString(), autoAck: true, consumer: consumer);
        return await Task.FromResult(string.Empty);

    }
}
