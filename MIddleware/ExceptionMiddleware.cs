
using Core.Api.Request.Response.Response;
using Core.API.Request.Response.Handler;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Core.Api.Request.Response.MIddleware;

public class ExceptionMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

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

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        ExceptionHandler.LogException(exception);
        var response = new BaseResponse(false, null, new FailedResultArgs(500));
        context.Response.ContentType = "application/json";

        var result = JsonSerializer.Serialize(response.FormatResponse(context));
        return context.Response.WriteAsync(result);
    }

}