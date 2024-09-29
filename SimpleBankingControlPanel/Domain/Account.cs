using System.ComponentModel.DataAnnotations;

namespace SimpleBankingControlPanel.Domain;

public class Account
{
    public Guid Id { get; set; }

    [MaxLength(100)] public string AccountNumber { get; set; } = string.Empty;

    public decimal Balance { get; set; }
}