using MediatR;
using SimpleBankingControlPanel.Application.Client.Dto;
using SimpleBankingControlPanel.Shared;
using SimpleBankingControlPanel.Shared.Enum;

namespace SimpleBankingControlPanel.Application.Client.Commands.UpdateClient;

public class UpdateClientCommand : IRequest<Result>
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
}