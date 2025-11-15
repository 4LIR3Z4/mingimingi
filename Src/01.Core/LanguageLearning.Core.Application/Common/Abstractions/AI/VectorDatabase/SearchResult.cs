namespace LanguageLearning.Core.Application.Common.Abstractions.AI.VectorDatabase;

public record SearchResult(ulong Id, double Score, string Metadata);
