using LanguageLearning.Core.Domain.LearningJourneys.Entities;

namespace LanguageLearning.Core.Application.LearningJourneys.Commands.CreateLearningJourney.DTO;
public sealed record CreateLearningJourneyResponse(long JourneyId);
public static class CCreateLearningJourneyResponseExtensions
{
    public static CreateLearningJourneyResponse ToCreateLearningJourneyResponseDto(this LearningJourney learningJourney)
    {
        return new CreateLearningJourneyResponse(learningJourney.Id);
    }
}

