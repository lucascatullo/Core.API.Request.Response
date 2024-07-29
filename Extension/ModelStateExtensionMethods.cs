using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Core.API.Request.Response.Extension;

public static class ModelStateExtensionMethods
{
    /// <summary>
    /// Returns a list of the model errors.
    /// </summary>
    /// <param name="modelState"></param>
    /// <returns></returns>
    public static IEnumerable<string> GetModelErrors(this ModelStateDictionary modelState) =>
        modelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
}