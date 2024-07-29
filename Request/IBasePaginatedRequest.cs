namespace Core.API.Request.Response.Request;

public interface IBasePaginatedRequest
{
    int PageSize { get; set; }
    int PageNum { get; set; }
}