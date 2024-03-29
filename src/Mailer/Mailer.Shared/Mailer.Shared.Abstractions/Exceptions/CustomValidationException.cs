using System.Net;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Mailer.Shared.Abstractions.Exceptions;

public class CustomValidationException : Exception
{
    public HttpStatusCode HttpCode { get; protected set; } = HttpStatusCode.BadRequest;
    public string Error { get; protected set; } = "validation_error";
    public ICollection<string> ValidationErrors { get; private set; }
    
    public CustomValidationException(ModelStateDictionary dict):base("Data model is not valid.")
    {
        ValidationErrors = dict.Values.SelectMany(m => m.Errors)
            .Select(e => e.ErrorMessage)
            .ToList();
    }
}