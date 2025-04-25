using Core.API.Request.Response.Request;
using Core.Models.Manager.Exception;
using Serilog;
using System.Text;
using System.Text.Json;

namespace Core.API.Request.Response.Handler;

public class ExceptionHandler
{

    /// <summary>
    /// Handles an exception trow. If is a Controlled exception, this prepares the response of type T for the controller (Use it to generate a descreptive error). If not, the exception is thrown.
    /// </summary>
    /// <typeparam name="T">Type of the produced response type.</typeparam>
    /// <param name="ex">Produced exception.</param>
    /// <param name="request">Request that produced the error.</param>
    /// <param name="exceptionLogger">This action is runned over the exception.</param>
    /// <returns>Response of type T if no exception is threw.</returns>
    public static T Handle<T>(System.Exception ex, object? request = null, Action<System.Exception, object?>? exceptionLogger = null) where T : BaseResponse, new()
    {
        var response = new T();
        exceptionLogger?.Invoke(ex, request);
        if (ex is IControlledException)
        {
            var exception = (ex as IControlledException)!;
            response.Success = false;
            response.ErrorCode = exception.ErrorCode;
            response.ErrorMessage = exception.Message;
            response.FancyError = exception.FancyError;
            response.Errors = exception.Errors;
            response.DescriptiveError = exception.DescriptiveCode;
        }
        else
        {
            throw ex;
        }
        return response;
    }

    /// <summary>
    /// Handles an exception trow. If is a Controlled exception, this prepares the response of type T for the controller (Use it to generate a descreptive error). If not, the exception is thrown.
    /// </summary>
    /// <typeparam name="T">Type of the produced response type.</typeparam>
    /// <param name="ex">Produced exception.</param>
    /// <param name="request">Request that produced the error.</param>
    /// <param name="logException">if the exception is logged using Serilog.</param>
    /// <returns>Response of type T if no exception is threw.</returns>
    public static T Handle<T>(System.Exception ex, object? request = null, bool logException = false) where T : BaseResponse, new()
        => 
        Handle<T>(ex, request, (System.Exception e, object? r) =>
        {
            if (logException)
                LogException(e, r);
        });

    private static void LogException(System.Exception e, object? request) 
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"Time: {DateTime.UtcNow} UTC.");

        if(request is not null) stringBuilder.AppendLine($"Caused by request: {JsonSerializer.Serialize(request)}");

        if (e is IControlledException) 
        {
            var controlledException = (e as IControlledException)!;
            stringBuilder.AppendLine($"Error: {controlledException.DescriptiveCode}.");
            stringBuilder.AppendLine($"Message: {controlledException.Message}");
        }
        else
        {
            stringBuilder.AppendLine($"Exception threw: {e.GetType()}");
            stringBuilder.AppendLine($"Message: {e.Message}");
            stringBuilder.AppendLine($"Stacktrace: {e.StackTrace}");
        }
    }
}