using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Mailer.Api.Models.Attachments;
using Microsoft.AspNetCore.Mvc;

namespace Mailer.Api.Models;

/// <summary>
/// 
/// </summary>
public static class Extensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });
        
        services.AddScoped<IValidator<AddNewAttachmentDto>, AddNewAttachmentDtoValidator>();
        
        services.AddFluentValidationAutoValidation();

        return services;
    }
}