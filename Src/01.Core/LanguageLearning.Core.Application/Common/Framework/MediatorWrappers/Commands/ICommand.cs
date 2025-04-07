
namespace LanguageLearning.Core.Application.Common.Framework.MediatorWrappers;

public interface ICommand : IBaseCommand
{
}

public interface ICommand<TReponse> : IBaseCommand
{
}

public interface IBaseCommand
{
}