using Core.API.Request.Response.Response;

namespace Core.Api.Request.Response.Response.SingleResult;

public record SuccessRequestInProgressResponse : BaseSuccessResponse
{
    public string SocketEndPoint { get; set; }
    public string CheckEndPoint { get; set; }
}
