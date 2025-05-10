namespace LanguageLearning.Core.Application.Common.Framework.MediatorWrappers.Commands;

public interface ICommand : IBaseCommand
{
}

public interface ICommand<TReponse> : IBaseCommand
{
}

public interface IBaseCommand
{
}