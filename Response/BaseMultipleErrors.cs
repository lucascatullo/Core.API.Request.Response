namespace Core.API.Request.Response.Response;

class BaseMultipleErrors : BaseErrorResponse, IMultipleError
{
    public ICollection<string>? Errors { get; set; }
}
