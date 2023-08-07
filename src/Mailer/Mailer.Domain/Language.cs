namespace Mailer.Domain;

public record Language
{
    public string CultureName { get; private set; } = String.Empty;
}