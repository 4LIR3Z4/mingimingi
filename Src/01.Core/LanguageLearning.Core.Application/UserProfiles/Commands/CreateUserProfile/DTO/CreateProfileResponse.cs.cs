using LanguageLearning.Core.Domain.UserProfiles.Entities;

namespace LanguageLearning.Core.Application.UserProfiles.Commands.CreateUserProfile.DTO;
public record CreateProfileResponse(long ProfileId);
public static class CreateProfileResponseExtensions
{
    public static CreateProfileResponse ToCreateProfileResponseDto(this UserProfile userProfile)
    {
        return new CreateProfileResponse(userProfile.Id);
    }
}
