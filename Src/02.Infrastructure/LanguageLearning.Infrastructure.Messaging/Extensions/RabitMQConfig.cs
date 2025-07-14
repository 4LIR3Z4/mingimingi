using LanguageLearning.Core.Application.Common.Abstractions.Messaging;
using LanguageLearning.Infrastructure.Messaging.RabbitMQ;
using Microsoft.Extensions.DependencyInjection;

namespace LanguageLearning.Infrastructure.Messaging.Extensions;
public static class RabitMQConfig
{
    public static void RegisterMessageBroker(
        this IServiceCollection services,
         MessageBrokerSettings? settings)
    {

        services.AddSingleton<IMessageBroker>(provider =>
        {
            if (settings is null)
            {
                throw new Exception("MessageBrokerSettings is null");
            }
            return MessageBroker.InitializeAsync(settings).GetAwaiter().GetResult();

        });

    }
}
