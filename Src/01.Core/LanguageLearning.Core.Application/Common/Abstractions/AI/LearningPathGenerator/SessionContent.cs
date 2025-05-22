using LanguageLearning.Core.Domain.LearningJourneys.Enums;

namespace LanguageLearning.Core.Application.Common.Abstractions.AI.LearningPathGenerator;

public sealed record Content(
    string Title,
    string ContentData,
    string ContentMetadata,
    int TimeNeededToComplete,
    SkillType SkillType,
    ContentType ContentType,
    ContentDifficulty ContentDifficulty);

public sealed record SessionContent(
    List<Content> Contents
);
