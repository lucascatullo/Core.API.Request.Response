namespace Core.API.Request.Response.Request;

public class BasePaginatedRequest : IBasePaginatedRequest
{
    public int PageSize { get; set; } = 500;
    public int PageNum { get; set; } = 1;
}