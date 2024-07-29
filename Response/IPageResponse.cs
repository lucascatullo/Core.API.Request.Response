
namespace Core.API.Request.Response.Response;

public interface IPageResponse<T> where T : class
{
    bool HasNextPage { get; set; }
    IEnumerable<T> Response { get; set; }
}