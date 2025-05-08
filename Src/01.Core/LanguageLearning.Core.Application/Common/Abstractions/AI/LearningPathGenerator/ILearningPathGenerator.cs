using LanguageLearning.Core.Domain.Prompts.Entities;

namespace LanguageLearning.Core.Application.Common.Abstractions.AI.LearningPathGenerator;
public interface ILearningPathGenerator
{
    public Task<int> CalculateTotalSessionsAsync(UserLearningProfile profile, Prompt prompt);
    public Task<SessionContent> GenerateSessionContentAsync(UserLearningProfile profile, Prompt prompt);
    public Task<SessionAssessment> GenerateSessionAssessmentAsync(UserLearningProfile profile, Prompt prompt);
}
