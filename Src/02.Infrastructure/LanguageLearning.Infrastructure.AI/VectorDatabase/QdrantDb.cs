using LanguageLearning.Core.Application.Common.Abstractions.AI.VectorDatabase;
using Qdrant.Client;
using Qdrant.Client.Grpc;

namespace LanguageLearning.Infrastructure.AI.VectorDatabase;

public class QdrantDb : IVectorDatabase
{
    private const string CollectionName = "my_collection";
    private readonly QdrantClient _client;

    public QdrantDb()
    {
        _client = new QdrantClient("localhost");

    }

    public async Task IndexEmbeddingAsync(ulong id, float[] embedding, ContentMetadata payload, CancellationToken cancellationToken)
    {
        if (await _client.CollectionExistsAsync(CollectionName, cancellationToken) == false)
        {
            await _client.CreateCollectionAsync(CollectionName,
                new VectorParams { Size = 768, Distance = Distance.Cosine });
        }
        await _client.UpsertAsync(
            "collectionTest",
            new[]
            {
                new PointStruct
                {
                    Id = id,
                    Vectors = embedding,
                    Payload = {

                        ["text"] = payload.Text,
                        ["translation"] = payload.Translation ?? string.Empty,
                        ["language_id"] = payload.LanguageId,
                        ["difficulty"] = payload.Difficulty,
                        ["topic"] = payload.Topic,
                        ["tags"] = string.Join(",", payload.Tags),
                        ["audio_url"] = payload.AudioUrl ?? string.Empty,
                        ["importance"] = payload.Importance,
                        ["lesson_id"] = payload.LessonId ?? string.Empty,
                        ["exercise_type"] = payload.ExerciseType ?? string.Empty,
                        ["source_model"] = payload.SourceModel ?? string.Empty,
                        ["created_at_utc"] = payload.CreatedAtUtc.ToString("o")
                    }
                }
            },
            cancellationToken: cancellationToken);
    }

  

    public async Task<IReadOnlyList<SearchResult>> SearchSimilarAsync(float[] embedding, int topK, CancellationToken cancellationToken)
    {
        var response = await _client.SearchAsync(
            CollectionName,
            embedding,
            limit: (uint)topK,
            cancellationToken: cancellationToken);

        return response.Select(x => new SearchResult(x.Id.Num, x.Score, x.Payload.TryGetValue("metadata", out var md) ? md.ToString()! : string.Empty
        )).ToList();
    }
}
