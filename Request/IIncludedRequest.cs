namespace Core.API.Request.Response.Request;

public interface IIncludedRequest
{
    string? Includes { get; set; }
}