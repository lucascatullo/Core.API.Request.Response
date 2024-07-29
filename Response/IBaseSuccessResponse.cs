namespace Core.API.Request.Response.Response;

public interface IBaseSuccessResponse
{
    public bool Success { get; set; }
    public object Body { get; set; }
}
