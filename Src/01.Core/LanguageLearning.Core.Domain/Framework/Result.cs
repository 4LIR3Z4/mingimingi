using System.Diagnostics.CodeAnalysis;

namespace LanguageLearning.Core.Domain.Framework;
public class Result
{
    protected internal Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
        {
            throw new InvalidOperationException();
        }

        if (!isSuccess && error == Error.None)
        {
            throw new InvalidOperationException();
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; }

    public static Result Success() => new(true, Error.None);

    public static Result Failure(Error error) => new(false, error);

    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

    public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);

    public static Result<TValue> Create<TValue>(TValue? value) =>
        value is not null ? Success(value) : Failure<TValue>(Error.NullValue);
}


public class Result<TValue> : Result
{
    private readonly TValue? _value;

    protected internal Result(TValue? value, bool isSuccess, Error error)
        : base(isSuccess, error)
    {
        _value = value;
    }
    public R Match<R>(Func<TValue, R> successHandler, Func<Error, R> errorHandler)
    {
        if (IsSuccess)
        {
            return successHandler(Value!);
        }
        else
        {
            return errorHandler(Error);
        }
    }
    [NotNull]
    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("Invalid access to failure result.");

    public static implicit operator Result<TValue>(TValue? value) => Create(value);
}
//public class Result<T>
//{
//    public bool Succeded { get; private set; }
//    public bool Failed => !Succeded;
//    public T? Value { get; private set; }
//    public Error Error { get; private set; }
//    private Result(bool success, T? value, Error error)
//    {
//        Succeded = success;
//        Value = value;
//        Error = error;
//    }
//    public static Result<T> Success(T value)
//    {
//        return new Result<T>(true, value, Error.None);
//    }
//    public static Result<T> Fail(Error error)
//    {
//        return new Result<T>(false, default, error);
//    }
//    public R Match<R>(Func<T, R> successHandler, Func<Error, R> errorHandler)
//    {
//        if (Succeded)
//        {
//            return successHandler(Value!); // Use ! to assert non-null value
//        }
//        else
//        {
//            return errorHandler(Error);
//        }
//    }
//}