namespace LanguageLearning.Core.Application.Common.Abstractions.Messaging;
public static class QueueConfig
{
    static Exchange journeyDirectExchange = new Exchange("LanguageLearning.Ex.Journey.Direct");
    public static Queue JourneyCreatedQueue = new Queue("LanguageLearning.Q.JourneyCreated", journeyDirectExchange);

    public static List<Queue> GetAllQueues() => new List<Queue>
    {
        JourneyCreatedQueue
    };
}
