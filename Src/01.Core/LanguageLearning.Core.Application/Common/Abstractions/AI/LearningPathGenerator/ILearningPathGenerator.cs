using LanguageLearning.Core.Domain.UserProfiles.Entities;

namespace LanguageLearning.Core.Application.Common.Abstractions.AI.LearningPathGenerator;
public interface ILearningPathGenerator
{
    public Task<int> CalculateTotalSessionsAsync(UserLearningProfile profile);
    public Task<SessionContent> GenerateSessionContentAsync(UserLearningProfile profile);
    public Task<SessionAssessment> GenerateSessionAssessmentAsync(UserLearningProfile profile);
}
