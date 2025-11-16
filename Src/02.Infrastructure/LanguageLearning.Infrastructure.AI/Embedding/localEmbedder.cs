using LanguageLearning.Core.Application.Common.Abstractions.AI.Embedding;
using System.Net.Http.Json;
using System.Text.Json;

namespace LanguageLearning.Infrastructure.AI.Embedding;

public class localEmbedder : IEmbedding
{
    private readonly HttpClient _httpClient;

    public localEmbedder(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<float[]> GenerateEmbeddingAsync(string text, CancellationToken cancellationToken = default)
    {
        var request = new
        {
            model = "nomic-embed-text", // local model served by Ollama
            prompt = text
        };

        var response = await _httpClient.PostAsJsonAsync("http://localhost:11434/api/embeddings", request, cancellationToken);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadFromJsonAsync<JsonElement>(cancellationToken: cancellationToken);
        var array = json.GetProperty("embedding").EnumerateArray().Select(x => (float)x.GetDouble()).ToArray();

        return array;
    }
}
