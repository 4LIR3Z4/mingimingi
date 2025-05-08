namespace LanguageLearning.Core.Domain.Prompts.Exceptions;
public sealed class NotAllPromptParametersHaveValueException : ArgumentException
{
    public NotAllPromptParametersHaveValueException(string message, string paramName) : base(message, paramName)
    {
    }
}
