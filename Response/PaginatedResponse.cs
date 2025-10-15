
using Core.API.Request.Response.Request;

namespace Core.API.Request.Response.Response;

public record PaginatedResponse : BaseResponse, IPaginatedResponse
{
    public PaginatedResponse(bool Success, object? Body, bool HasNextPage) : base(Success, Body, null) 
    {
        this.HasNextPage = HasNextPage;
    }
    public bool HasNextPage { get; }
}
