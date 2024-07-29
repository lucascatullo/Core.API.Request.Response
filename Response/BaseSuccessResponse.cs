
namespace Core.API.Request.Response.Response;

public class BaseSuccessResponse : IBaseSuccessResponse
{
    public bool Success { get; set; } = true;
    public object Body { get; set; }
}
