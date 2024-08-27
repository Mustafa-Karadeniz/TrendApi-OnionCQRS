using FluentValidation;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;



namespace TrendApi.Application.Exceptions;

public class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex) 
        {
            await HandleExeptionAsync(httpContext, ex);
        }
    }

    private static Task HandleExeptionAsync(HttpContext httpContext, Exception exception)
    {
        var  statusCode = GetStatusCode(exception);
        httpContext.Response.ContentType = "appplication/json";
        httpContext.Response.StatusCode = statusCode;

        if (exception.GetType() == typeof(ValidationException))
            return httpContext.Response.WriteAsync(new ExceptionModel
            {
                Errors = ((ValidationException)exception).Errors.Select(x => x.ErrorMessage),
                StatusCode = StatusCodes.Status400BadRequest
            }.ToString());

        List<string> errors = new()
        {
            $"Hata Mesajı :{exception.Message}",            
        };
        return httpContext.Response.WriteAsync(new ExceptionModel
        {
            Errors = errors,
            StatusCode = statusCode
        }.ToString());
    }

    private static int GetStatusCode(Exception exception) =>
    exception switch
    {
        BadRequestException => StatusCodes.Status400BadRequest,
        NotFoundException => StatusCodes.Status404NotFound,
        ValidationException => StatusCodes.Status422UnprocessableEntity,
        _ => StatusCodes.Status500InternalServerError
    };
}
