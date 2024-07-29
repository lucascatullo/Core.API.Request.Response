namespace Core.API.Request.Response.Response;

public class BaseErrorResponse : IBaseErrorResponse
{
    public bool Success { get => false; }
    public string? ErrorMessage { get; set; }
    public int ErrorCode { get; set; }
    public string? DescriptiveError { get; set; }
    public string? FancyError { get; set; }
}
