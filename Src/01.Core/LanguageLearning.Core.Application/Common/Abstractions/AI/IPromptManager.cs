namespace LanguageLearning.Core.Application.Common.Abstractions.AI;
public interface IPromptManager
{
    public Task<string> RenderPrompt(string promptKey, Dictionary<string, string> parameters);
}
