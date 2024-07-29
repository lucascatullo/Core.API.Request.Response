namespace Core.API.Request.Response.Response;

class BaseSuccessPaginatedResponse : BaseSuccessResponse
{
    public bool HasNextPage { get; set; }
}
