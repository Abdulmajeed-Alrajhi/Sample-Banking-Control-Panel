using System.ComponentModel.DataAnnotations;

namespace SimpleBankingControlPanel.Domain;

public class SearchParameter
{
    public Guid Id { get; set; }
    [MaxLength(250)] public string Parameter { get; set; } = string.Empty;
    public DateTime SearchedAt { get; set; }
}