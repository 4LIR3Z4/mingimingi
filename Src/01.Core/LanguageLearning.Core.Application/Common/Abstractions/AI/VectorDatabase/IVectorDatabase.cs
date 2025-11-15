namespace LanguageLearning.Core.Application.Common.Abstractions.AI.VectorDatabase;

public interface IVectorDatabase
{
    Task IndexEmbeddingAsync(ulong id, float[] embedding, string metadata, CancellationToken cancellationToken);
    Task<IReadOnlyList<SearchResult>> SearchSimilarAsync(float[] embedding, int topK, CancellationToken cancellationToken);
}