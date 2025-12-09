using Core.Api.Request.Response.Response;
using Core.Api.Request.Response.Response.Base;
using Core.Api.Request.Response.Response.Collection;
using Core.Api.Request.Response.Response.SingleResult;
using Core.API.Request.Response.Response;
using Microsoft.AspNetCore.Http;

namespace Core.API.Request.Response.Request;

/// <summary>
/// Initializes a new instance of <see cref="BaseResponse"/> representing the outcome of a service operation.
/// </summary>
/// <param name="Success">True when the operation completed successfully; false when it failed.</param>
/// <param name="Body">The payload to return on success. Commonly a DTO or primitive; may be <c>null</c> when there is no success payload.</param>
/// <param name="Error">Optional failure details used to build an error response when <paramref name="Success"/> is <c>false</c>.</param>
/// <remarks>
/// This record is a simple, transport-friendly container. For best results place typed success DTOs in <paramref name="Body"/>
/// and structured error information in <see cref="FailedResultArgs"/> for <paramref name="Error"/>.
/// </remarks>
public record BaseResponse(bool Success, object? Body, FailedResultArgs? Error = null)
{

    /// <summary>
    /// Produces the appropriate HTTP response object for this instance and sets the HTTP status code on the provided <see cref="HttpContext"/>.
    /// </summary>
    /// <param name="_httpContext">The current HTTP context. The method sets <c>_httpContext.Response.StatusCode</c> as a side effect.</param>
    /// <returns>
    /// On success, returns one of the success DTOs:
    /// <see cref="BaseSuccessResponse"/>, <see cref="BaseSuccessPaginatedResponse"/>,
    /// <see cref="BaseSuccessPaginatedCountResponse"/>, or <see cref="SuccessRequestInProgressResponse"/>,
    /// depending on the concrete subtype. On failure, returns a <see cref="BaseErrorResponse"/> populated from <see cref="FailedResultArgs"/>.
    /// </returns>
    /// <remarks>
    /// Behavior summary:
    /// - Success: sets status code 200 and returns a success wrapper with <c>Body</c> assigned. If this instance is a paginated or in-progress subtype,
    ///   the method returns the corresponding specialized success response and may set additional properties (e.g. HasNextPage, TotalResults, SocketEndPoint).
    /// - In-progress requests: sets status code 202 and returns <see cref="SuccessRequestInProgressResponse"/>.
    /// - Failure: constructs a <see cref="BaseErrorResponse"/> from <see cref="FailedResultArgs"/> (defaults to 400 when <c>Error</c> is null),
    ///   sets the response status code to the error code and returns the error object.
    /// </remarks>
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
            var error = Error ?? new FailedResultArgs(400);
            BaseErrorResponse baseErrorResponse = new()
            {
                FancyError = error.FancyError,
                ErrorMessage = error.ErrorMessage,
                ErrorCode = error.ErrorCode,
                DescriptiveError = error.DescriptiveError
            };
            _httpContext.Response.StatusCode = baseErrorResponse.ErrorCode;
            return baseErrorResponse;
        }
    }

    /// <summary>
    /// Creates a failed <see cref="BaseResponse"/> from the provided <see cref="FailedResultArgs"/>.
    /// </summary>
    /// <param name="args">Failure details used to populate the response's <see cref="FailedResultArgs"/>.</param>
    /// <returns>
    /// A new <see cref="BaseResponse"/> with <see cref="Success"/> set to <c>false</c>, <see cref="Body"/> set to <c>null</c>,
    /// and <see cref="Error"/> set to <paramref name="args"/>. Intended as a concise factory for error responses.
    /// </returns>
    /// <remarks>
    /// This is a convenience factory used to produce an error response when only failure details are available.
    /// It does not modify the incoming <paramref name="args"/> instance and performs no side effects.
    /// </remarks>
    public static BaseResponse From(FailedResultArgs args) => new(false, null, args);
}