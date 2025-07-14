using LanguageLearning.Core.Application.Common.Abstractions.Messaging;
using LanguageLearning.Core.Application.Common.Abstractions.Messaging.Dto;
using LanguageLearning.Core.Application.Common.Framework.MediatorWrappers.Commands;
using LanguageLearning.Core.Application.LearningJourneys.Commands.CreateLearningPath;
using LanguageLearning.Core.Application.LearningJourneys.Commands.CreateLearningPath.DTO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LanguageLearning.Infrastructure.BackgroundServices;
internal class JourneyProcessingService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    public JourneyProcessingService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();
        using IServiceScope scope = _scopeFactory.CreateScope();
        var _messageBroker = scope.ServiceProvider.GetRequiredService<IMessageBroker>();
        var _commandDispatcher = scope.ServiceProvider.GetRequiredService<ICommandDispatcher>();
        _messageBroker.SubscribeToQueueAsync<JourneyMessage>(
            QueueConfig.JourneyCreatedQueue,
            async message =>
            {
                var result = await
            _commandDispatcher.DispatchAsync<CreateLearningPathCommand, CreateLearningPathResponse>
            (new CreateLearningPathCommand(new JourneyMessage(message.JourneyId, message.CreatedAt)));
            }, stoppingToken);
        return Task.CompletedTask;
    }
}
