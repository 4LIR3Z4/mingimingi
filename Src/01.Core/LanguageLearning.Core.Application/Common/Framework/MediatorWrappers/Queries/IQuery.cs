﻿namespace LanguageLearning.Core.Application.Common.Framework.MediatorWrappers;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}