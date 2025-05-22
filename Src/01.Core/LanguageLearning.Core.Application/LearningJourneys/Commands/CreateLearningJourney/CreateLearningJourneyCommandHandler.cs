using LanguageLearning.Core.Application.Common.Abstractions.Caching;
using LanguageLearning.Core.Application.Common.Abstractions.Identity;
using LanguageLearning.Core.Application.Common.Framework.MediatorWrappers.Commands;
using LanguageLearning.Core.Application.LearningJourneys.Commands.CreateLearningJourney.DTO;
using LanguageLearning.Core.Domain.LearningJourneys.Entities;

namespace LanguageLearning.Core.Application.LearningJourneys.Commands.CreateLearningJourney;
public sealed class CreateLearningJourneyCommandHandler :
    ICommandHandler<CreateLearningJourneyCommand, CreateLearningJourneyResponse>
{
    private readonly IDbContext _context;
    private readonly IIdGenerator _idGenerator;
    private readonly IReferenceDataCache _referenceDataCache;
    private readonly ICurrentUserService _currentUserService;
    private readonly TimeProvider _timeProvider;

    public CreateLearningJourneyCommandHandler(IDbContext context, IIdGenerator idGenerator, IReferenceDataCache referenceDataCache, ICurrentUserService currentUserService, TimeProvider timeProvider)
    {
        _context = context;
        _idGenerator = idGenerator;
        _referenceDataCache = referenceDataCache;
        _currentUserService = currentUserService;
        _timeProvider = timeProvider;
    }

    public async Task<Result<CreateLearningJourneyResponse>> Handle(
        CreateLearningJourneyCommand command,
        CancellationToken cancellationToken)
    {
        CreateLearningJourneyRequest journeyRequest = command.request;
        var languages = await _referenceDataCache.GetLanguagesAsync(cancellationToken);
        var targetLanguage = languages.Find(l => l.Id == journeyRequest.TargetLanguageId);
        if (targetLanguage is null)
        {
            return Result.Failure<CreateLearningJourneyResponse>(new Error("Language.NotFound", "The specified target language does not exist."));
        }


        var learningJourneyId = _idGenerator.GenerateId();
        var userId = _currentUserService.UserId;
        if (userId is null)
        {
            return Result.Failure<CreateLearningJourneyResponse>(new Error("User.NotFound", "User not found."));
        }

        List<LanguageProficiency> languageProficiencies = new List<LanguageProficiency>();
        languageProficiencies.Add(LanguageProficiency.Create(journeyRequest.ReadingProficiency, journeyRequest.WritingProficiency, journeyRequest.ListeningProficiency, journeyRequest.SpeakingProficiency, _timeProvider.GetUtcNow(), Domain.LearningJourneys.Enums.ProficiencyAdditionMethod.UserProvided));

        var learningJourney = LearningJourney.Create(learningJourneyId, (long)userId, targetLanguage.Id, languageProficiencies, new List<LearningPath>());



        _context.learningJourneys.Add(learningJourney);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success(learningJourney.ToCreateLearningJourneyResponseDto());

    }
}
