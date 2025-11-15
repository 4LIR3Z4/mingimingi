namespace LanguageLearning.Infrastructure.AI.VectorDatabase.Configuration;

internal class VectorDbOptions
{
    public string Endpoint { get; set; } = default!;
    public string ApiKey { get; set; } = default!;
    public string CollectionName { get; set; } = "embeddings";
}
