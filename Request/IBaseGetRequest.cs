namespace Core.API.Request.Response.Request;

public interface IBaseGetRequest
{
    IEnumerable<string>? Includes { get; set; }
}