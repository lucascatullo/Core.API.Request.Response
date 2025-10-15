namespace Core.Api.Request.Response.Response.Collection;

public record PaginatedCountResponse : PaginatedResponse
{
    public PaginatedCountResponse(bool Success, object? Body, bool HasNextPage, int TotalResults) : base(Success, Body, HasNextPage)
    {
        this.TotalResults = TotalResults;
    }
    public int TotalResults { get; }
}
