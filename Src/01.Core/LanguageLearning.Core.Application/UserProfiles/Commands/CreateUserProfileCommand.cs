using LanguageLearning.Core.Application.UserProfiles.Commands.DTO;

namespace LanguageLearning.Core.Application.UserProfiles.Commands;

public record CreateUserProfileCommand(CreateProfileRequest CreateDto) : ICommand<CreateProfileResponse>;
