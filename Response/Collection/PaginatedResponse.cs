namespace Core.Api.Request.Response.Response.Collection;

public record PaginatedResponse : BaseResponse
{
    public PaginatedResponse(bool Success, object? Body, bool HasNextPage) : base(Success, Body, null)
    {
        this.HasNextPage = HasNextPage;
    }
    public bool HasNextPage { get; }
}
