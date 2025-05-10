using LanguageLearning.Core.Domain.LearningJourneys.Enums;

namespace LanguageLearning.Core.Domain.LearningJourneys.Entities;
public sealed class LanguageProficiency : BaseEntity<int>
{
    public ProficiencyLevel ReadingProficiency { get; }
    public ProficiencyLevel WritingProficiency { get; }
    public ProficiencyLevel ListeningProficiency { get; }
    public ProficiencyLevel SpeakingProficiency { get; }
    public DateTimeOffset AddedDate { get; }
    public ProficiencyAdditionMethod AdditionMethod { get; }

    private LanguageProficiency()
    {

    }
    private LanguageProficiency(
        ProficiencyLevel readingProficiency,
        ProficiencyLevel writingProficiency,
        ProficiencyLevel listeningProficiency,
        ProficiencyLevel speakingProficiency,
        DateTimeOffset addedDate,
        ProficiencyAdditionMethod additionMethod
        )
    {
        ReadingProficiency = readingProficiency;
        WritingProficiency = writingProficiency;
        ListeningProficiency = listeningProficiency;
        SpeakingProficiency = speakingProficiency;
        AddedDate = addedDate;
        AdditionMethod = additionMethod;

    }
    public static LanguageProficiency Create(
        
        ProficiencyLevel readingProficiency,
        ProficiencyLevel writingProficiency,
        ProficiencyLevel listeningProficiency,
        ProficiencyLevel speakingProficiency,
        DateTimeOffset addedDate,
        ProficiencyAdditionMethod additionMethod
        )
    {
        return new LanguageProficiency(
            
            readingProficiency,
            writingProficiency,
            listeningProficiency,
            speakingProficiency,
            addedDate,
            additionMethod

        );
    }

}
