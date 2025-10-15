namespace Core.API.Request.Response.Response;

public record PaginatedCountResponse : PaginatedResponse, IPaginatedCountResponse
{
    public PaginatedCountResponse(bool Success, object? Body, bool HasNextPage, int TotalResults) : base(Success, Body, HasNextPage)
    {
        this.TotalResults = TotalResults;
    }
    public int TotalResults { get; }
}
