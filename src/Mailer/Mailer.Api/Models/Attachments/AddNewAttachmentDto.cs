using System.Data;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using FluentValidation;
using Mailer.Api.Common.Options;
using Microsoft.Extensions.Options;

namespace Mailer.Api.Models.Attachments;

/// <summary>
/// 
/// </summary>
public record AddNewAttachmentDto
{
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("media-type")]
    public required string MediaType { get; init; }
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("description")]
    public required string Description { get; init; }
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("inline")]
    public required bool Inline { get; init; }
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("file")]
    public required IFormFile File { get; init; }
};

internal class AddNewAttachmentDtoValidator : AbstractValidator<AddNewAttachmentDto>
{
    // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
    private readonly MimeTypeOptions _options;
    public AddNewAttachmentDtoValidator(IOptions<MimeTypeOptions> options)
    {
        _options = options.Value;
        
        RuleFor(x => x.Name)
            .MinimumLength(5)
            .WithName("name");
        RuleFor(p => p.MediaType)
            .NotEmpty()
            .WithName("media-type");
        RuleFor(p => p.MediaType)
            .Must(p => _options.AllowedMimeTypes.Contains(p))
            .WithName("media-type")
            .WithMessage("Not allowed media type.");
        RuleFor(p => p.Description)
            .NotEmpty()
            .WithName("description");
        RuleFor(p => p.File)
            .Must(p => p.Length > 0)
            .WithName("file")
            .WithMessage("File cannot be empty");
    }
}