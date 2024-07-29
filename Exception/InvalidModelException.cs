

using Core.Models.Manager.Exception;

namespace Core.API.Request.Response.Exception;

internal class InvalidModelException(string[] errors) : ExceptionArgs
{
    private readonly ICollection<string> _errors = errors;

    public override string DescriptiveStringCode => "REQUEST_HAS_MODEL_VALIDATION_ERRORS";
    public override string FancyError => "Something went wrong! Review your data and try again.";
    public override int ErrorCode => 400;
    public override ICollection<string>? Errors => _errors;
}
