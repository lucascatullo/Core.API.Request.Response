
using Core.API.Request.Response.Request;

namespace Core.API.Request.Response.Response;

public class RequestInProgressResponse : BaseResponse
{
    private const string CHECK_ENDPOINT_SOURCE = "/api/event/get/";
    /// <summary>
    /// Start of the class
    /// </summary>
    /// <param name="socketEndpoint">End point created by event service</param>
    /// <param name="eventId">Id of the created event</param>
    public RequestInProgressResponse()
    {
    }
    public string SocketEndPoint { get; set; }
    public string CheckEndPoint { get; set; }
    public void SetCheckEndPoint(string val) => CheckEndPoint = CHECK_ENDPOINT_SOURCE + val;
}
