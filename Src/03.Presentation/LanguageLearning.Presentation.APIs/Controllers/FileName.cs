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
}
