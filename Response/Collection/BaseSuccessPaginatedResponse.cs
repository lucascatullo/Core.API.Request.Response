using Core.API.Request.Response.Response;

namespace Core.Api.Request.Response.Response.Collection;

record BaseSuccessPaginatedResponse : BaseSuccessResponse
{
    public bool HasNextPage { get; set; }
}
