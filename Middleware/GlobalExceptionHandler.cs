using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using TodoAPI.Models;

namespace TodoAPI.Middleware
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext, 
            Exception exception,
            CancellationToken cancellationToken)
        {
            _logger.LogError(
                $"An error occurred while processing the request: {exception.Message}");

            var ErrorResponse = new ErrorResponse
            {
                Message = exception.Message
            };

            switch (exception)
            {
                case BadHttpRequestException:
                    ErrorResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    ErrorResponse.Title = exception.GetType().Name;
                    break;

                default:
                    ErrorResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                    ErrorResponse.Title = "Internal Server Error";
                    break;
            }

            httpContext.Response.StatusCode = ErrorResponse.StatusCode;

            await httpContext
                .Response
                .WriteAsJsonAsync(ErrorResponse, cancellationToken);

            return true;
        }
    }
}