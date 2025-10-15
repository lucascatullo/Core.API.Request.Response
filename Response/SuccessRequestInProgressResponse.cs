namespace Core.API.Request.Response.Response;

public record SuccessRequestInProgressResponse : BaseSuccessResponse
{
    public string SocketEndPoint { get; set; }
    public string CheckEndPoint { get; set; }
}
