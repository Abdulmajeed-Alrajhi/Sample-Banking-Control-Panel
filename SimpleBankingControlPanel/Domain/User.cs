using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SimpleBankingControlPanel.Domain;

public class User : IdentityUser
{
    [MaxLength(60)] public string FirstName { get; set; } = string.Empty;

    [MaxLength(60)] public string LastName { get; set; } = string.Empty;

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; }
}