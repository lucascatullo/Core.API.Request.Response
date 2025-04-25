
using Core.API.Request.Response.Handler;
using Core.API.Request.Response.Request;
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

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = ExceptionHandler.Handle<BaseResponse>(exception, context.Request, true);
        context.Response.ContentType = "application/json";

        var result = JsonSerializer.Serialize(response.FormatResponse(context));
        return context.Response.WriteAsync(result);
    }

}