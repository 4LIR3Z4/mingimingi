namespace LanguageLearning.Core.Application.Common.Abstractions.AI.LearningPathGenerator;
public interface ILearningPathGenerator
{
    public Task<int> CalculateTotalSessionsAsync(UserLearningProfile profile, CancellationToken cancellationToken = default);
    public Task<SessionContent> GenerateSessionContentAsync(UserLearningProfile profile, CancellationToken cancellationToken = default);
    public Task<SessionAssessment> GenerateSessionAssessmentAsync(UserLearningProfile profile, CancellationToken cancellationToken = default);
}
