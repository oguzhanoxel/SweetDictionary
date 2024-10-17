using System.Net;

namespace Core.Results;

public class DataResult<T> : Result
{
	public T? Data { get; }

	public DataResult(bool isSuccess, HttpStatusCode statusCode, T? data = default, string? message = null)
		: base(isSuccess, statusCode, message)
	{
		Data = data;
	}
}
