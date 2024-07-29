
namespace Core.API.Request.Response.Response;

public interface IMultipleError
{
    public ICollection<string>? Errors { get; set; }
}
