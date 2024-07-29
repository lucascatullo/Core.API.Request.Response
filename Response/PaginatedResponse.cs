
using Core.API.Request.Response.Request;

namespace Core.API.Request.Response.Response;

public class PaginatedResponse : BaseResponse, IPaginatedResponse
{
    public bool HasNextPage { get; set; }
}
