using Microsoft.AspNetCore.Builder;

namespace Core.Exceptions;

public static class ExceptionMiddlewareExtensions
{
	public static void UseCustomExceptionMiddleware(this IApplicationBuilder app)
	{
		app.UseMiddleware<ExceptionMiddleware>();
	}
}