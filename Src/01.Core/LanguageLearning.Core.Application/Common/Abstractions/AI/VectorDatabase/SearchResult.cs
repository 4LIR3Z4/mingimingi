namespace LanguageLearning.Core.Application.Common.Abstractions.AI.VectorDatabase;

public sealed record SearchResult(ulong Id, double Score, string Metadata);
