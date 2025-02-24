using LanguageLearning.Core.Domain.Languages.Constants;

namespace LanguageLearning.Core.Domain.Languages.Entities;
public sealed class Language : BaseAggregateRoot<int>
{
    public string Name { get; init; } = string.Empty;
    public string Code { get; init; } = string.Empty;
    private readonly List<ProficiencyExam> _SupportedExams = new();
    public IReadOnlyList<ProficiencyExam> SupportedExams => _SupportedExams.AsReadOnly();
    private Language(string code, string name)
    {
        Code = code.ToUpperInvariant();
        Name = name;
    }
    private Language() { }
    public static Language Create(string code, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Language name cannot be null or empty.", nameof(name));
        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentException("Language code cannot be null or empty.", nameof(code));
        if (code.Length != LanguageConstants.CodeLength)
            throw new ArgumentException($"Language code must be exactly {LanguageConstants.CodeLength} characters long.", nameof(code));
        if (name.Length < LanguageConstants.NameMinLength)
            throw new ArgumentException($"Language name must be at least {LanguageConstants.NameMinLength} characters long.", nameof(name));
        if (name.Length > LanguageConstants.NameMaxLength)
            throw new ArgumentException($"Language name must be at most {LanguageConstants.NameMaxLength} characters long.", nameof(name));

        return new Language(name.Trim(), code.Trim().ToUpperInvariant());
    }
    public void AddExam(string examName)
    {
        var exam = ProficiencyExam.Create(examName);

        if (_SupportedExams.Any(e => e.ExamName.Equals(examName, StringComparison.OrdinalIgnoreCase)))
            throw new Exception($"Exam {examName} already exists for this language");

        _SupportedExams.Add(exam);
    }
    public override string ToString()
    {
        return $"{Name} ({Code})";
    }
}
