namespace LanguageLearning.Core.Application.Common.Framework.MediatorWrappers.Queries;

public interface IQueryHandler<TQuery, TResponse> 
    where TQuery : IQuery<TResponse>
{
    Task<Result<TResponse>> Handle(TQuery query, CancellationToken cancellationToken);
}