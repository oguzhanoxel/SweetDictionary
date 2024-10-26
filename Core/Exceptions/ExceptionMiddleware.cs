using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace Core.Exceptions;

public class ExceptionMiddleware
{
	private readonly RequestDelegate _next;

	public ExceptionMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task InvokeAsync(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (Exception ex)
		{
			await HandleExceptionAsync(context, ex);
		}
	}

	private Task HandleExceptionAsync(HttpContext context, Exception exception)
	{
		context.Response.ContentType = "application/json";

		return exception switch
		{
			ValidationException validationException => CreateValidationException(context, validationException),
			BusinessException businessException => CreateBusinessException(context, businessException),
			AuthorizationException authorizationException => CreateAuthorizationException(context, authorizationException),
			_ => CreateInternalException(context, exception),
		};
	}

	private Task CreateInternalException(HttpContext context, Exception exception)
	{
		context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

		var problem = new ProblemDetails
		{
			Status = StatusCodes.Status500InternalServerError,
			Type = "https://example.com/probs/internal",
			Title = "Internal exception",
			Detail = exception.Message,
			Instance = context.Request.Path
		};

		return WriteResponseAsync(context, problem);
	}

	private Task CreateAuthorizationException(HttpContext context, Exception exception)
	{
		context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

		var problem = new AuthorizationProblemDetails
		{
			Status = StatusCodes.Status401Unauthorized,
			Type = "https://example.com/probs/authorization",
			Title = "Authorization exception",
			Detail = exception.Message,
			Instance = context.Request.Path
		};

		return WriteResponseAsync(context, problem);
	}

	private Task CreateBusinessException(HttpContext context, Exception exception)
	{
		context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

		var problem = new BusinessProblemDetails
		{
			Status = StatusCodes.Status400BadRequest,
			Type = "https://example.com/probs/business",
			Title = "Business exception",
			Detail = exception.Message,
			Instance = context.Request.Path
		};

		return WriteResponseAsync(context, problem);
	}

	private Task CreateValidationException(HttpContext context, ValidationException validationException)
	{
		context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

		var errors = validationException.Errors
			.GroupBy(e => e.PropertyName)
			.ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());

		var problem = new ValidationProblemDetails()
		{
			Errors = errors,
			Status = StatusCodes.Status400BadRequest,
			Type = "https://example.com/probs/validation",
			Title = "Validation error(s)",
			Detail = "One or more validation errors occurred.",
			Instance = context.Request.Path
		};

		return WriteResponseAsync(context, problem);
	}
	private static Task WriteResponseAsync(HttpContext context, ProblemDetails problem)
	{
		var json = JsonSerializer.Serialize(problem, new JsonSerializerOptions
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			WriteIndented = true
		});

		return context.Response.WriteAsync(json);
	}
}
