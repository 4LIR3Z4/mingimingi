using LanguageLearning.Core.Domain.Languages.Constants;

namespace LanguageLearning.Core.Domain.Languages.Entities;

public sealed class ProficiencyExam : BaseEntity<int>
{
    public string ExamName { get; private set; }
    private ProficiencyExam(
        string examName)
    {
        ExamName = examName;
    }

    public static ProficiencyExam Create(string examName)
    {
        if (string.IsNullOrWhiteSpace(examName))
            throw new ArgumentException("Exam name cannot be empty", nameof(examName));
        if (examName.Length > ProficiencyExamConstants.NameMaxLength)
            throw new ArgumentException($"Exam name must be at most {ProficiencyExamConstants.NameMaxLength}", nameof(examName));
        return new ProficiencyExam(examName);
    }


}

