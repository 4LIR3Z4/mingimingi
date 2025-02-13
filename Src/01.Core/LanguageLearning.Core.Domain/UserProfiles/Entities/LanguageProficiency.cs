using LanguageLearning.Core.Domain.SharedKernel.Entities;
using LanguageLearning.Core.Domain.UserProfiles.Enums;

namespace LanguageLearning.Core.Domain.UserProfiles.Entities;
public class LanguageProficiency : BaseEntity<int>
{
    public Language Language { get; }
    public ProficiencyLevel ReadingProficiency { get; }
    public ProficiencyLevel WritingProficiency { get; }
    public ProficiencyLevel ListeningProficiency { get; }
    public ProficiencyLevel SpeakingProficiency { get; }
    public DateTime AddedDate { get; }
    public ProficiencyAdditionMethod additionMethod { get; }

    private LanguageProficiency()
    {

    }
    private LanguageProficiency(
        Language language,
        ProficiencyLevel readingProficiency,
        ProficiencyLevel writingProficiency,
        ProficiencyLevel listeningProficiency,
        ProficiencyLevel speakingProficiency
        )
    {
        Language = language;
        ReadingProficiency = readingProficiency;
        WritingProficiency = writingProficiency;
        ListeningProficiency = listeningProficiency;
        SpeakingProficiency = speakingProficiency;
        
    }
    public static LanguageProficiency Create(
        Language language,
        ProficiencyLevel readingProficiency,
        ProficiencyLevel writingProficiency,
        ProficiencyLevel listeningProficiency,
        ProficiencyLevel speakingProficiency
        )
    {
        return new LanguageProficiency(
            language,
            readingProficiency,
            writingProficiency,
            listeningProficiency,
            speakingProficiency
            
        );
    }
    
}
