namespace Identity.Domain.Entities;

public class ConfirmRegistrationToken
{
    public Guid Guid { get; set; } = Guid.NewGuid();
    public DateTime ValidAfter { get; set; } = DateTime.UtcNow;
    public DateTime ValidBefore { get; set; }  = DateTime.UtcNow;
    public int UserId { get; set; }
    //public User? User { get; set; }
    
    public string Token { get; set; } = String.Empty;
}