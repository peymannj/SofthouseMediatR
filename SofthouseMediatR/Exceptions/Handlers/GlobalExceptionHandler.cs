using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace SofthouseMediatR.Exceptions.Handlers;

public class GlobalExceptionHandler : IExceptionHandler
{
	private readonly ILogger<GlobalExceptionHandler> _logger;

	public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
	{
		_logger = logger;
	}

	public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
	{
		_logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

		var problemDetails = new ProblemDetails
		{
			Instance =  $"{httpContext.Request.Method} {httpContext.Request.Path}",
			Detail = exception.Message
		};

		switch (exception)
		{
			case ArgumentException:
				httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
				problemDetails.Status = StatusCodes.Status400BadRequest;
				problemDetails.Title = "Bad Request.";

				break;

			case OperationCanceledException:
				httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
				problemDetails.Status = StatusCodes.Status400BadRequest;
				problemDetails.Title = "Bad Request.";

				break;

			default:
			{
				httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
				problemDetails.Status = StatusCodes.Status500InternalServerError;
				problemDetails.Title = "An unexpected error occurred.";

				break;
			}
		}

		await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

		return true;
	}
}
