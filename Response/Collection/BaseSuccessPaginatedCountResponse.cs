using Core.API.Request.Response.Response;

namespace Core.Api.Request.Response.Response.Collection;

record BaseSuccessPaginatedCountResponse : BaseSuccessResponse
{
    public bool HasNextPage { get; set; }
    public int TotalResults { get; set; }
}