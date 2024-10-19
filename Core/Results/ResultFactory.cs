using System.Net;

namespace Core.Results;

public static class ResultFactory
{
	public static Result Success(HttpStatusCode statusCode = HttpStatusCode.OK, string? message = null) =>
		new Result(true, statusCode, message);

	public static Result Failure(HttpStatusCode statusCode = HttpStatusCode.BadRequest, string message = "Operation failed.") =>
		new Result(false, statusCode, message);

	public static DataResult<T> Success<T>(T data, HttpStatusCode statusCode = HttpStatusCode.OK, string? message = null) =>
		new DataResult<T>(true, statusCode, data, message);

	public static DataResult<T> Failure<T>(T data, HttpStatusCode statusCode = HttpStatusCode.BadRequest, string message = "Operation failed.") =>
		new DataResult<T>(false, statusCode, default, message);
}
