using Microsoft.AspNetCore.Mvc;

namespace BitCoio.Extensions
{
    public static class ResultExtensions
    {
        public static IResult<T> Fail<T>(this IResult result) => Result<T>.Fail(result.Message);

        public static IResult<T> Fail<T>(this T data) => Result<T>.Fail(data);

        public static IResult<T> Success<T>(this T data) => Result<T>.Success(data);

        public static IResult<T> Success<T>(this T data, string message) => Result<T>.Success(data, message);

        public static IActionResult ApiResult<T>(this IResult<T> result) => new ApiResult<T>(result);

        public static IActionResult ApiResult<T>(this Task<IResult<T>> result) => new ApiResult<T>(result.Result);

        public static IActionResult ApiResult(this IResult result) => new ApiResult(result);

        public static IActionResult ApiResult(this Task<IResult> result) => new ApiResult(result.Result);

        public static IActionResult ApiResult<T>(this T result) => ApiResult(Result<T>.Success(result));

        public static IActionResult ApiResult<T>(this Task<T> result) => ApiResult(result.Result);
    }

    public sealed class ApiResult : IActionResult
    {
        private readonly IResult _result;

        public ApiResult(IResult result) => _result = result;

        public Task ExecuteResultAsync(ActionContext context)
        {
            return !_result.Successed ? context.UnprocessableEntity(_result) : context.Ok(_result);
        }
    }

    public sealed class ApiResult<T> : IActionResult
    {
        private readonly IResult<T> _result;

        public ApiResult(IResult<T> result) => _result = result;

        public Task ExecuteResultAsync(ActionContext context)
        {
            return !_result.Successed ? context.UnprocessableEntity(_result) : context.Ok(_result);
        }
    }

    public static class ActionContextExtensions
    {
        public static Task Ok(this ActionContext context, object value) => new OkObjectResult(value).ExecuteResultAsync(context);

        public static Task UnprocessableEntity(this ActionContext context, object error) => new UnprocessableEntityObjectResult(error).ExecuteResultAsync(context);
    }

    public class Result : IResult
    {
        protected Result()
        {
        }

        public string Message { get; protected set; }

        public bool Successed { get; protected set; }

        public static IResult Fail() => new Result
        {
            Successed = false
        };

        public static IResult Fail(string message) => new Result
        {
            Successed = false,
            Message = message
        };

        public static IResult Success() => new Result
        {
            Successed = true
        };

        public static IResult Success(string message) => new Result
        {
            Successed = true,
            Message = message
        };
    }

    public class Result<T> : Result, IResult<T>
    {
        protected Result()
        {
        }

        public T Notifications { get; set; }

        public T Data { get; private init; }

        public new static IResult<T> Fail() => new Result<T>
        {
            Successed = false
        };

        public static IResult<T> Fail(T notifications) => new Result<T>
        {
            Successed = false,
            Notifications = notifications,
            Data = default(T)
        };

        public new static IResult<T> Fail(string message) => new Result<T>
        {
            Successed = false,
            Message = message
        };

        public new static IResult<T> Success() => new Result<T>
        {
            Successed = true
        };

        public new static IResult<T> Success(string message) => new Result<T>
        {
            Successed = true,
            Message = message
        };

        public static IResult<T> Success(T data) => new Result<T>
        {
            Successed = true,
            Data = data
        };

        public static IResult<T> Success(T data, string message) => new Result<T>
        {
            Successed = true,
            Data = data,
            Message = message
        };
    }

    public interface IResult
    {
        public string Message { get; }

        public bool Successed { get; }
    }

    public interface IResult<out T> : IResult
    {
        public T Data { get; }
    }
}
