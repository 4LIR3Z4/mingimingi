using LanguageLearning.Core.Application.UserProfiles.Commands.DTO;

namespace LanguageLearning.Core.Application.UserProfiles.Commands;

public record CreateUserProfileCommand(CreateProfileRequest request) : ICommand<CreateProfileResponse>;
