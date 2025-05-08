using LanguageLearning.Core.Application.Common.Abstractions.AI.LearningPathGenerator;
using LanguageLearning.Core.Domain.Prompts.Entities;

namespace LanguageLearning.Infrastructure.AI.Services;
public sealed class LearningPathGenerator : ILearningPathGenerator
{
    public async Task<int> CalculateTotalSessionsAsync(UserLearningProfile profile, Prompt prompt)
    {
        var promptParameters = new Dictionary<string, string>
        {
            { "TargetLanguage", "english"  }
        };
        var promptText = prompt.RenderTemplate(promptParameters);
        return await Task.FromResult(1);
    }

    public Task<SessionAssessment> GenerateSessionAssessmentAsync(UserLearningProfile profile, Prompt prompt)
    {
        throw new NotImplementedException();
    }

    public Task<SessionContent> GenerateSessionContentAsync(UserLearningProfile profile, Prompt prompt)
    {
        throw new NotImplementedException();
    }
}
