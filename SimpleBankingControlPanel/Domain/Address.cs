using System.ComponentModel.DataAnnotations;

namespace SimpleBankingControlPanel.Domain;

public class Address
{
    public Guid Id { get; set; }
    [MaxLength(50)] public string Country { get; set; } = string.Empty;
    [MaxLength(50)] public string City { get; set; } = string.Empty;
    [MaxLength(250)] public string Street { get; set; } = string.Empty;
    [MaxLength(10)] public string ZipCode { get; set; } = string.Empty;
}