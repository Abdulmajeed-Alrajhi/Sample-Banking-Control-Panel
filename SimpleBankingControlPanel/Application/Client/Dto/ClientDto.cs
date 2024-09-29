using SimpleBankingControlPanel.Shared.Enum;

namespace SimpleBankingControlPanel.Application.Client.Dto;

public class ClientDto
{
    public Guid Id { get; set; }

    public string Email { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PersonalId { get; set; }

    public string ProfilePhoto { get; set; }

    public string MobileNumber { get; set; }

    public Gender Sex { get; set; }
    public AddressDto Address { get; set; }
    public List<AccountDto> Accounts { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}