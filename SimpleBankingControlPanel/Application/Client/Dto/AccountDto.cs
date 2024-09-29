namespace SimpleBankingControlPanel.Application.Client.Dto;

public class AccountDto
{
    public Guid Id { get; set; }
    public string AccountNumber { get; set; }

    public decimal Balance { get; set; }
}