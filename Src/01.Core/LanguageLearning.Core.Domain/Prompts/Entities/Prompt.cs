using LanguageLearning.Core.Domain.Prompts.ValueObjects;

namespace LanguageLearning.Core.Domain.Prompts.Entities;
public sealed class Prompt : BaseAggregateRoot<int>
{
    public PromptName Name { get; private set; }
    public PromptVersion Version { get; private set; }
    public PromptTemplate Template { get; private set; }
    public PromptDescription Description { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool IsActive { get; private set; }
    public PromptParameters DefaultParameters { get; private set; }

    private Prompt(
        PromptName name,
        PromptVersion version,
        PromptTemplate template,
        PromptDescription description,
        PromptParameters defaultParameters)
    {
        Name = name;
        Version = version;
        Template = template;
        Description = description;
        CreatedAt = DateTime.UtcNow;
        IsActive = true;
        DefaultParameters = defaultParameters;
    }
    public static Prompt Create(
        string name,
        string version,
        string template,
        string description,
        Dictionary<string, string> defaultParameters)
    {
        return new Prompt(
            new PromptName(name),
            new PromptVersion(version),
            new PromptTemplate(template),
            new PromptDescription(description),
            new PromptParameters(defaultParameters ?? new Dictionary<string, string>()));
    }

    public void Deactivate()
    {
        IsActive = false;
    }
    public void UpdateContent(string template, string description)
    {
        Template = new PromptTemplate(template);
        Description = new PromptDescription(description);
    }
    public void UpdateDefaultParameters(Dictionary<string, string> parameters)
    {
        DefaultParameters = new PromptParameters(parameters);
    }
}
