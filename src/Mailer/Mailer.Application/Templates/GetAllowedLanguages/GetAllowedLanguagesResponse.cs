namespace Mailer.Application.Templates.GetAllowedLanguages;

public record GetAllowedLanguagesResponse
{
    public IReadOnlyCollection<string> Languages { get; init; } = default!;
    public int AllCount { get; init; }
};