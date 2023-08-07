namespace Mailer.Domain;

public record EmailType
{
    public string Name { get; private set; } = default!;
}