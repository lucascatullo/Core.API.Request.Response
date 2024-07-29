using Core.API.Request.Response.Response;
using Microsoft.AspNetCore.Http;

namespace Core.API.Request.Response.Request;

public class BaseResponse : IMultipleError, IBaseErrorResponse, IBaseSuccessResponse
{
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }
    public ICollection<string>? Errors { get; set; }
    public string? FancyError { get; set; }
    public object Body { get; set; }
    public int ErrorCode { get; set; }
    public string? DescriptiveError { get; set; }


    public object FormatResponse(HttpContext _httpContext)
    {
        if (Success)
        {
            _httpContext.Response.StatusCode = 200;

            dynamic val = new BaseSuccessResponse();
            if (GetType() == typeof(PaginatedResponse))
            {
                val = new BaseSuccessPaginatedResponse();
                val.HasNextPage = (this as PaginatedResponse)!.HasNextPage;

            }
            else if (GetType() == typeof(PaginatedCountResponse))
            {
                val = new BaseSuccessPaginatedCountResponse();
                val.HasNextPage = (this as PaginatedCountResponse)!.HasNextPage;
                val.TotalResults = (this as PaginatedCountResponse)!.TotalResults;
            }
            else if (GetType() == typeof(RequestInProgressResponse))
            {
                val = new SuccessRequestInProgressResponse();
                val.SocketEndPoint = (this as RequestInProgressResponse)!.SocketEndPoint;
                val.CheckEndPoint = (this as RequestInProgressResponse)!.CheckEndPoint;
                _httpContext.Response.StatusCode = 202;
            }
            val.Body = Body;
            return val;
        }
        else
        {
            if (Errors != null && Errors.Count > 0)
            {
                BaseMultipleErrors baseMultipleErrors = new();
                baseMultipleErrors.Errors = Errors;
                baseMultipleErrors.ErrorCode = ErrorCode;
                baseMultipleErrors.ErrorMessage = ErrorMessage;
                baseMultipleErrors.FancyError = FancyError;
                _httpContext.Response.StatusCode = 400;
                return baseMultipleErrors;
            }

            BaseErrorResponse baseErrorResponse = new();
            baseErrorResponse.FancyError = FancyError;
            baseErrorResponse.ErrorMessage = ErrorMessage;
            baseErrorResponse.ErrorCode = ErrorCode;
            baseErrorResponse.DescriptiveError = DescriptiveError;
            _httpContext.Response.StatusCode = baseErrorResponse.ErrorCode;
            return baseErrorResponse;
        }


    }


}