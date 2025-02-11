namespace LanguageLearning.Core.Application.Common.Framework.MediatorWrappers;

public interface IQueryHandler<TQuery, TResponse> 
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}