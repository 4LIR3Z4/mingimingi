namespace LanguageLearning.Core.Application.Common.Abstractions.Messaging;
public class Queue
{
    public string Name { get; }
    public Exchange Exchange { get; }
    public bool Durable { get; }
    public bool Exclusive { get; }
    public bool AutoDelete { get; }
    public IDictionary<string, object?> Arguments { get; }

    public Queue(
        string name,
        Exchange exchange,
        bool durable = true,
        bool exclusive = false,
        bool autoDelete = false,
        IDictionary<string, object?>? arguments = null)
    {
        Name = name;
        Exchange = exchange;
        Durable = durable;
        Exclusive = exclusive;
        AutoDelete = autoDelete;
        Arguments = arguments ?? new Dictionary<string, object?>();
    }
}