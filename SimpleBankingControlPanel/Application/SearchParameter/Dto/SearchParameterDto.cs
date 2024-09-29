namespace SimpleBankingControlPanel.Application.SearchParameter.Dto;

public class SearchParameterDto
{
    public int Id { get; set; }
    public string Parameter { get; set; } = string.Empty;
    public DateTime SearchedAt { get; set; }
}