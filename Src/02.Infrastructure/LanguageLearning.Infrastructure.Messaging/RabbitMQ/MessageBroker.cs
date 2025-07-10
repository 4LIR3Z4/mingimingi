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

    public async Task PublishMessageAsync<T>(T message, Queue queue, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var body = JsonSerializer.SerializeToUtf8Bytes(message);

        await _channel.BasicPublishAsync(queue.Exchange.Name, queue.Name, body, cancellationToken);

        await Task.CompletedTask;
    }
    public async static Task DeclareTopologyAsync(
        IChannel channel,
        List<Queue> queues,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var exchangeGroups = queues
            .GroupBy(q => q.Exchange)
            .ToList();

        foreach (var exchangeGroup in exchangeGroups)
        {
            var exchange = exchangeGroup.Key;

            await channel.ExchangeDeclareAsync(
                exchange: exchange.Name,
                type: exchange.Type.ToString().ToLower(),
                durable: exchange.Durable,
                autoDelete: exchange.AutoDelete,
                arguments: exchange.Arguments,
                cancellationToken: cancellationToken);

            foreach (var queue in exchangeGroup)
            {
                await channel.QueueDeclareAsync(
                    queue: queue.Name,
                    durable: queue.Durable,
                    exclusive: queue.Exclusive,
                    autoDelete: queue.AutoDelete,
                    arguments: queue.Arguments,
                    cancellationToken: cancellationToken);


                await channel.QueueBindAsync(
                    queue: queue.Name,
                    exchange: exchange.Name,
                    routingKey: queue.Name,
                    cancellationToken: cancellationToken);



            }
        }

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
        await DeclareTopologyAsync(channel, QueueConfig.GetAllQueues(), cancellationToken);

        /*await channel.ExchangeDeclareAsync(exchange: ExchangeName, type: ExchangeType.Direct, durable: true, cancellationToken: cancellationToken);
        foreach (var queue in Enum.GetValues(typeof(Queue)).Cast<Queue>())
        {
            QueueDeclareOk queueDeclareResult = await channel.QueueDeclareAsync(queue: queue.ToString(), durable: true, exclusive: false, autoDelete: false, cancellationToken: cancellationToken);
            await channel.QueueBindAsync(queue: queue.ToString(), exchange: ExchangeName, routingKey: queue.ToString(), cancellationToken: cancellationToken);
        }*/
        return new MessageBroker(connection, channel, settings);
    }
    public async Task SubscribeToQueueAsync<T>(Queue queue, Func<T, Task> handler, CancellationToken cancellationToken)
    {
        var consumer = new AsyncEventingBasicConsumer(_channel);
        string message = string.Empty;
        consumer.ReceivedAsync += async (model, ea) =>
        {
            cancellationToken.ThrowIfCancellationRequested();
            var body = ea.Body.ToArray();
            message = Encoding.UTF8.GetString(body);
            try
            {
                var deserializedMessage = JsonSerializer.Deserialize<T>(message);
                if (deserializedMessage is not null)
                {
                    await handler(deserializedMessage);
                    await _channel.BasicAckAsync(ea.DeliveryTag, false, cancellationToken);
                    return;

                }
                await _channel.BasicRejectAsync(ea.DeliveryTag, false, cancellationToken);
            }
            catch (Exception ex)
            {
                await _channel.BasicRejectAsync(ea.DeliveryTag, false, cancellationToken);
            }
            return;
        };

        await _channel.BasicConsumeAsync(queue.Name, autoAck: false, consumer: consumer, cancellationToken);
        await Task.CompletedTask;

    }
}
