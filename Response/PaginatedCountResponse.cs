namespace Core.API.Request.Response.Response;

public class PaginatedCountResponse : PaginatedResponse, IPaginatedCountResponse
{
    public int TotalResults { get; set; }
}
