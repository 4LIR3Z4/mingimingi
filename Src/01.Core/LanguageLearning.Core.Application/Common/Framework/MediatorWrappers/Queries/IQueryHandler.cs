namespace LanguageLearning.Core.Application.Common.Framework.MediatorWrappers;

public interface IQueryHandler<TQuery, TResponse> 
    where TQuery : IQuery<TResponse>
{
    Task<Result<TResponse>> Handle(TQuery query, CancellationToken cancellationToken);
}