namespace LanguageLearning.Core.Application.Common.Abstractions.AI.Embedding;

public interface IEmbedding
{
    Task<float[]> GenerateEmbeddingAsync(string text, CancellationToken cancellationToken = default);

}
