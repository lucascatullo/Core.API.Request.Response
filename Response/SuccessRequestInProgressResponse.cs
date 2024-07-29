namespace Core.API.Request.Response.Response;

public class SuccessRequestInProgressResponse : BaseSuccessResponse
{
    public string SocketEndPoint { get; set; }
    public string CheckEndPoint { get; set; }
}
