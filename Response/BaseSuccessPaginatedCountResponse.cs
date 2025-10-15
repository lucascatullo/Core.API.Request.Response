namespace Core.API.Request.Response.Response;

record BaseSuccessPaginatedCountResponse : BaseSuccessResponse
{
    public bool HasNextPage { get; set; }
    public int TotalResults { get; set; }
}