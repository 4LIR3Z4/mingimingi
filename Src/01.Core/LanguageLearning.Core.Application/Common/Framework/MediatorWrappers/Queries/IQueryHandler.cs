namespace LanguageLearning.Core.Application.Common.Framework.MediatorWrappers;

public interface IQueryHandler<TQuery, TResponse> where TQuery : IQuery<TResponse>
{
}