using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using StorageStation.Application.Common.ErrorHandling;

namespace StorageStation.Web.Common.Middleware.ErrorHandling;

public class ErrorHandlerMiddleware
{
    private const string SomethingWentWrong = "Oops! Something went wrong!";
    private const string ResponseContentType = "application/json";

    private readonly RequestDelegate _next;
    private readonly IHostEnvironment _environment;

    public ErrorHandlerMiddleware(RequestDelegate next, IHostEnvironment environment)
    {
        this._next = next;
        this._environment = environment;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await this._next(context);
        }
        catch (Exception ex)
        {
            var response = context.Response;
            response.ContentType = ResponseContentType;

            response.StatusCode = ex switch
            {
                AppException => (int)HttpStatusCode.BadRequest,
                KeyNotFoundException => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError
            };

            var exceptionResponse = this._environment.IsDevelopment()
                ? ExceptionResponseModel.New(context.Response.StatusCode, ex.Message, ex.StackTrace)
                : ExceptionResponseModel.New(response.StatusCode, SomethingWentWrong);

            await response.WriteAsync(JsonSerializer.Serialize(exceptionResponse, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }));
        }
    }
}