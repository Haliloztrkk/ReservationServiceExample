namespace ReservationService.Application.Common.Models;

public class Result
{
    internal Result(bool succeeded, IEnumerable<string> errors)
    {
        Succeeded = succeeded;
        Errors = errors.ToArray();
    }

    public bool Succeeded { get; init; }

    public string[] Errors { get; init; }

    public static Result Success()
    {
        return new Result(true, Array.Empty<string>());
    }

    public static Result Failure(IEnumerable<string> errors)
    {
        return new Result(false, errors);
    }
    public static Result<T> Success<T>(T data)
    {
        return new Result<T>(true, Array.Empty<string>(), data);
    }

    public static Result<T> Failure<T>(IEnumerable<string> errors)
    {
        return new Result<T>(false, errors, default(T));
    }
}
public class Result<T> : Result
{
    internal Result(bool succeeded, IEnumerable<string> errors, T data) : base(succeeded, errors)
    {
        Data = data;
    }
    public T Data { get; init; }
}
