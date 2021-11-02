using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using BulkBuilder.Application.Common.Exceptions;
using BulkBuilder.Application.Common.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BulkBuilder.Application.Common.RequestInterceptors
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An exception has occurred!");
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var errors = GetErrors(exception);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = errors[0].Code;

            var handledResponse = new HandledResponseWrapper
            {
                Errors = errors
            };

            var serializerOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            await context.Response.WriteAsync(JsonSerializer.Serialize(handledResponse, serializerOptions));
        }

        private List<Error> GetErrors(Exception exception)
        {
            if (exception is ValidationException validationException)
            {
                return new List<Error>(validationException.Errors.Select(failure => new Error
                {
                    Code = 400,
                    Message = failure.ErrorMessage
                }));
            }

            var errors = new List<Error> { GetCommonError(exception) };
            AddInnerErrors(errors, exception);
            return errors;
        }

        private static Error GetCommonError(Exception exception)
        {
            var code = (int)HttpStatusCode.InternalServerError;
            var message = exception.Message;
            switch (exception)
            {
                case HttpException httpException:
                    code = (int)httpException.Code;
                    if (code == 404)
                    {
                        message = httpException.Message == $"Exception of type '{typeof(HttpException)}' was thrown."
                            ? "The resource you are looking for does not exist."
                            : httpException.Message;
                    }
                    break;
                case ValidationException:
                    code = (int)HttpStatusCode.BadRequest;
                    message = null;
                    break;
            }

            return new Error { Code = code, Message = message };
        }

        private void AddInnerErrors(List<Error> errors, Exception exception)
        {
            if (exception.InnerException == null)
                return;

            errors.Add(GetCommonError(exception.InnerException));
            AddInnerErrors(errors, exception.InnerException);
        }
    }
}
