using LanguageLearning.Core.Application.Common.Abstractions.Caching;
using LanguageLearning.Core.Application.Common.Abstractions.Identity;
using LanguageLearning.Core.Application.Common.Framework.MediatorWrappers.Commands;
using LanguageLearning.Core.Application.LearningJourneys.Commands.CreateLearningJourney.DTO;
using LanguageLearning.Core.Domain.LearningJourneys.Entities;
using LanguageLearning.Core.Domain.LearningJourneys.Errors;

namespace LanguageLearning.Core.Application.LearningJourneys.Commands.CreateLearningJourney;
public sealed class CreateLearningJourneyCommandHandler(IDbContext context, IIdGenerator idGenerator, IReferenceDataCache referenceDataCache, ICurrentUserService currentUserService, TimeProvider timeProvider) :
    ICommandHandler<CreateLearningJourneyCommand, CreateLearningJourneyResponse>
{
    public async Task<Result<CreateLearningJourneyResponse>> Handle(
        CreateLearningJourneyCommand command,
        CancellationToken cancellationToken)
    {
        CreateLearningJourneyRequest journeyRequest = command.request;
        var languages = await referenceDataCache.GetLanguagesAsync(cancellationToken);
        var targetLanguage = languages.Find(l => l.Id == journeyRequest.TargetLanguageId);
        if (targetLanguage is null)
        {
            return Result.Failure<CreateLearningJourneyResponse>(LearningJourneyErrors.LanguageNotFound);
        }


        var learningJourneyId = idGenerator.GenerateId();
        var userId = currentUserService.UserId;
        if (userId is null)
        {
            return Result.Failure<CreateLearningJourneyResponse>(LearningJourneyErrors.UserNotFound);
        }

        List<LanguageProficiency> languageProficiencies = new List<LanguageProficiency>();
        languageProficiencies.Add(LanguageProficiency.Create(journeyRequest.ReadingProficiency, journeyRequest.WritingProficiency, journeyRequest.ListeningProficiency, journeyRequest.SpeakingProficiency, timeProvider.GetUtcNow(), Domain.LearningJourneys.Enums.ProficiencyAdditionMethod.UserProvided));

        var learningJourney = LearningJourney.Create(learningJourneyId, (long)userId, targetLanguage.Id, languageProficiencies);


        context.LearningJourneys.Add(learningJourney);
        await context.SaveChangesAsync(cancellationToken);

        return Result.Success(learningJourney.ToCreateLearningJourneyResponseDto());

    }
}
