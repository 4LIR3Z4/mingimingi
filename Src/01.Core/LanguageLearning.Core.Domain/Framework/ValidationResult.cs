namespace LanguageLearning.Core.Domain.Framework;
public record ValidationResult(List<Error>? Errors = null)
{
    public List<Error> Errors { get; init; } = Errors ?? new List<Error>();
    public bool IsValid => Errors?.Any() == false;

    public bool HasErrors => Errors?.Any() ?? false;
}