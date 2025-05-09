using LanguageLearning.Core.Domain.LearningJourney.Enums;

namespace LanguageLearning.Core.Application.LearningJourney.Commands.CreateLearningJourney.DTO;
public sealed class CreateLearningJourneyRequest
{
    public long UserId { get; set; }
    public int LearningLanguageId { get; set; }
    public LearningTarget LearningTarget { get; private set; }
    public int PracticePerDayInMinutes { get; private set; }
    public ProficiencyLevel ReadingProficiency { get; set; }
    public ProficiencyLevel WritingProficiency { get; set; }
    public ProficiencyLevel ListeningProficiency { get; set; }
    public ProficiencyLevel SpeakingProficiency { get; set; }    

}
