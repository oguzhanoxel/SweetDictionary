using System.Net;

namespace Core.Results;

public class Result
{
	public bool IsSuccess { get; }
	public string? Message { get; }
	public HttpStatusCode StatusCode { get; }

	public Result(bool isSuccess, HttpStatusCode statusCode, string? message = null)
	{
		IsSuccess = isSuccess;
		StatusCode = statusCode;
		Message = message;
	}
}
