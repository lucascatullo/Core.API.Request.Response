

using Core.API.Request.Response.Request;

public class BaseGetRequest : IBaseGetRequest
{
    public IEnumerable<string>? Includes { get; set; }
}