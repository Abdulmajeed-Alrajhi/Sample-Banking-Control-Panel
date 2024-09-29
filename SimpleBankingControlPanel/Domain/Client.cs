using System.ComponentModel.DataAnnotations;
using SimpleBankingControlPanel.Shared.Enum;

namespace SimpleBankingControlPanel.Domain;

public class Client
{
    public Guid Id { get; set; }

    [MaxLength(250)] public string Email { get; set; } = string.Empty;
    [MaxLength(60)] public string FirstName { get; set; } = string.Empty;
    [MaxLength(60)] public string LastName { get; set; } = string.Empty;
    [MaxLength(11)] public string PersonalId { get; set; } = string.Empty;
    [MaxLength(1000)] public string ProfilePhoto { get; set; } = string.Empty;
    [MaxLength(16)] public string MobileNumber { get; set; } = string.Empty;
    public Gender Sex { get; set; }
    public Address Address { get; set; } = new();
    public List<Account> Accounts { get; set; } = [];
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; set; }
}