namespace LanguageLearning.Core.Application.Common.Abstractions.Messaging;
public class Exchange
{
    public string Name { get; }
    public ExchangeType Type { get; }
    public bool Durable { get; }
    public bool AutoDelete { get; }
    public IDictionary<string, object?> Arguments { get; }

    public Exchange(
        string name,
        ExchangeType type = ExchangeType.Direct,
        bool durable = true,
        bool autoDelete = false,
        IDictionary<string, object?>? arguments = null)
    {
        Name = name;
        Type = type;
        Durable = durable;
        AutoDelete = autoDelete;
        Arguments = arguments ?? new Dictionary<string, object?>();
    }
}