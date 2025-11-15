using LanguageLearning.Core.Application.Common.Abstractions.VectorDatabase;
using Qdrant.Client;
using Qdrant.Client.Grpc;

namespace LanguageLearning.Infrastructure.VectorDatabase.Clients;

public class Qdrant : IVectorDatabase
{
    private const string CollectionName = "my_collection";
    private readonly QdrantClient _client;

    public Qdrant()
    {
        _client = new QdrantClient("localhost");

    }

    public async Task IndexEmbeddingAsync(ulong id, float[] embedding, string metadata, CancellationToken cancellationToken)
    {
        if (await _client.CollectionExistsAsync(CollectionName, cancellationToken) == false)
        {
            await _client.CreateCollectionAsync(CollectionName,
        new VectorParams { Size = 512, Distance = Distance.Cosine });
        }
        await _client.UpsertAsync(
            "collectionTest",
            new[]
            {
                new PointStruct
                {
                    Id = id,
                    Vectors = embedding,
                    Payload = { ["metadata"] = metadata }
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
