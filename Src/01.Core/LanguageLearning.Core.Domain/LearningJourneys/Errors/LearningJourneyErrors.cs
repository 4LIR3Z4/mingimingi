namespace LanguageLearning.Core.Domain.LearningJourneys.Errors;
public static class LearningJourneyErrors
{
    public static readonly Error LanguageNotFound = new Error("Language.NotFound", "The specified target language does not exist.");
    public static readonly Error UserNotFound = new Error("User.NotFound", "User not found.");

}
