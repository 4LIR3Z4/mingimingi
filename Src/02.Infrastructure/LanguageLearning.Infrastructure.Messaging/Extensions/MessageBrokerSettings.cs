namespace LanguageLearning.Infrastructure.Messaging.Extensions;
public sealed class MessageBrokerSettings
{
    public string HostName { get; set; } = null!;
    public int Port { get; set; }
    public string VirtualHost { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
}
