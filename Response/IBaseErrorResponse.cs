namespace Core.API.Request.Response.Response;

public interface IBaseErrorResponse
{
    public string? ErrorMessage { get; set; }
    public int ErrorCode { get; set; }
    public string? FancyError { get; set; }
    public string? DescriptiveError { get; set; }
}