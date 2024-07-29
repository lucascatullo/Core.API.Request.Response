using Core.API.Request.Response.Exception;
using Core.API.Request.Response.Extension;
using Core.Models.Manager.Exception;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Core.API.Request.Response.Request;

public class BaseModelRequest : IBaseModelRequest
{

    /// <summary>
    /// Returns true if the model is valid or throws an exception if is it not.
    /// </summary>
    /// <param name="modelState">Current ModelState</param>
    /// <returns></returns>
    public virtual bool ModelIsValid(ModelStateDictionary modelState) => modelState.IsValid ?
        true : throw new Exception<InvalidModelException>(new InvalidModelException(modelState.GetModelErrors().ToArray()));
}