using LanguageLearning.Core.Domain.Languages.Entities;
using LanguageLearning.Core.Domain.LearningJourney.Enums;

namespace LanguageLearning.Core.Domain.LearningJourney.Entities;
public class LanguageProficiency : BaseEntity<int>
{
    public ProficiencyLevel ReadingProficiency { get; }
    public ProficiencyLevel WritingProficiency { get; }
    public ProficiencyLevel ListeningProficiency { get; }
    public ProficiencyLevel SpeakingProficiency { get; }
    public DateTime AddedDate { get; }
    public ProficiencyAdditionMethod AdditionMethod { get; }

    private LanguageProficiency()
    {

    }
    private LanguageProficiency(
        ProficiencyLevel readingProficiency,
        ProficiencyLevel writingProficiency,
        ProficiencyLevel listeningProficiency,
        ProficiencyLevel speakingProficiency,
        DateTime addedDate,
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
        DateTime addedDate,
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
