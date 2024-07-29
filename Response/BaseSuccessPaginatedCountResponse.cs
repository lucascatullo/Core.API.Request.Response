namespace Core.API.Request.Response.Response;

class BaseSuccessPaginatedCountResponse : BaseSuccessResponse
{
    public bool HasNextPage { get; set; }
    public int TotalResults { get; set; }
}