using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Core.API.Request.Response.Request;

interface IBaseModelRequest
{
    public bool ModelIsValid(ModelStateDictionary modelState);
}