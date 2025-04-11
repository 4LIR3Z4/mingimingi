using LanguageLearning.Core.Application.Common.Framework.MediatorWrappers.Commands;
using LanguageLearning.Core.Application.Common.Framework.MediatorWrappers.Queries;
using LanguageLearning.Core.Application.UserProfiles.Commands;
using LanguageLearning.Core.Application.UserProfiles.Commands.DTO;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LanguageLearning.Presentation.API.Controllers;
//how to use valdiation :
/*
    private readonly ICommandHandler<CreateUserCommand, int> _createUserHandler;
    private readonly ValidationBehavior<CreateUserCommand, int> _validationBehavior;

    public UserService(
        ICommandHandler<CreateUserCommand, int> createUserHandler, 
        ValidationBehavior<CreateUserCommand, int> validationBehavior)
    {
        _createUserHandler = createUserHandler;
        _validationBehavior = validationBehavior;
    }

    public async Task<int> CreateUser(CreateUserCommand command)
    {
        return await _validationBehavior.HandleWithValidation(
            command, 
            _createUserHandler.Handle, 
            CancellationToken.None
        );
    }
*/
public class FileName
{
    public FileName(
        ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }
    private readonly ICommandDispatcher _commandDispatcher;
    public async Task<string> GetUserProfile(long id)
    {
        var result = await
            _commandDispatcher.Dispatch<CreateUserProfileCommand, CreateProfileResponse>
            (new CreateUserProfileCommand(
            new CreateProfileRequest()
            {
                Age = 25,
            }));

        return "Ok(result)";
    }
}
