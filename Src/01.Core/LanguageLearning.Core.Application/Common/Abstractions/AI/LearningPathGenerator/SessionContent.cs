namespace LanguageLearning.Core.Application.Common.Abstractions.AI.LearningPathGenerator;
public sealed record SessionContent(
    string Title,
    string ContentData,
    string ContentMetadata,
    int TimeNeededToComplete
);
