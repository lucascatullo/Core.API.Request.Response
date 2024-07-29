using Core.API.Request.Response.Request;
using Core.Models.Manager.Exception;

namespace Core.API.Request.Response.Handler;

public class ExceptionHandler
{

    public static T Handle<T>(System.Exception ex, object? request = null) where T : BaseResponse, new()
    {
        var response = new T();

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
            //falta logger SDK aca
            throw ex;
        }
        return response;
    }
}