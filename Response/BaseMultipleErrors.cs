namespace Core.API.Request.Response.Response;

public record BaseMultipleErrors : BaseErrorResponse, IMultipleError
{
    public ICollection<string>? Errors { get; set; }
}
