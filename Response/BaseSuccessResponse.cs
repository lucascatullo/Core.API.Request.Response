
namespace Core.API.Request.Response.Response;

public record BaseSuccessResponse : IBaseSuccessResponse
{
    public bool Success { get; set; } = true;
    public object Body { get; set; }
}
