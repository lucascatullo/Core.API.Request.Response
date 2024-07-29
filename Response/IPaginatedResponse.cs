namespace Core.API.Request.Response.Response;

public interface IPaginatedResponse
{
    public bool HasNextPage { get; set; }
}
