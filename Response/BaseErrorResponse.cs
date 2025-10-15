namespace Core.API.Request.Response.Response;

public record BaseErrorResponse : IBaseErrorResponse
{
    public bool Success { get => false; }
    public string? ErrorMessage { get; set; }
    public int ErrorCode { get; set; }
    public string? DescriptiveError { get; set; }
    public string? FancyError { get; set; }
}
