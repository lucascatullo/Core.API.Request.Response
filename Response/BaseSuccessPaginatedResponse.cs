namespace Core.API.Request.Response.Response;

record BaseSuccessPaginatedResponse : BaseSuccessResponse
{
    public bool HasNextPage { get; set; }
}
