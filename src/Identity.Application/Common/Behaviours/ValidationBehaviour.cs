using System.Net;
using FluentValidation;
using Identity.Shared.Common;
using Identity.Shared.Enums;
using Identity.Shared.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using ValidationException = FluentValidation.ValidationException;

namespace Identity.Application.Common.Behaviours;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest,TResponse> 
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    private readonly ILogger _logger;
    
    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators, ILogger<ValidationBehaviour<TRequest, TResponse>> logger)
    {
        _validators = validators;
        _logger = logger;
    }
    
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Validators: {count}",_validators.Count());
        foreach (var val in _validators)
        {
            _logger.LogInformation("Validator is Auth: {type}",val is IAuthValidator);
        }
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators.Where(v => v is IAuthValidator)
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null).ToList();
            if (failures.Count != 0)
            {
                string message = "";
                for (int i = 0; i < failures.Count(); i++)
                {
                    message+=failures[i].ErrorMessage;
                    if (i < failures.Count() - 1)
                    {
                        message += "\n";
                    }
                }
                throw new ProblemException(HttpStatusCode.BadRequest,AuthErrorResponseNames.InvalidRequest,message);
            }
            
            failures = _validators.Where(v => v is not IAuthValidator)
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null).ToList();
            if (failures.Count != 0)
            {
                throw new ValidationException(failures);
            }
            
        }
        return await next();
    }
}