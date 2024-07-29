
namespace Core.API.Request.Response.Response;

public class PageResponse<T> : IPageResponse<T> where T : class
{
    public IEnumerable<T> Response { get; set; }
    public bool HasNextPage { get; set; }
}
