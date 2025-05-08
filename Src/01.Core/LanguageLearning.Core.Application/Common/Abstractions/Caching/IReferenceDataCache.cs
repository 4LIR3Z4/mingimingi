using LanguageLearning.Core.Domain.Languages.Entities;
using LanguageLearning.Core.Domain.Prompts.Entities;
using LanguageLearning.Core.Domain.SharedKernel.Entities;

namespace LanguageLearning.Core.Application.Common.Abstractions.Caching;

public interface IReferenceDataCache
{
    Task<List<Hobby>> GetHobbiesAsync(CancellationToken cancellationToken);
    Task<List<Interest>> GetInterestsAsync(CancellationToken cancellationToken);
    Task<List<Language>> GetLanguagesAsync(CancellationToken cancellationToken);
    Task<List<Country>> GetCountriesAsync(CancellationToken cancellationToken);
    Task<List<Prompt>> GetPromptsAsync(CancellationToken cancellationToken);
}

