using MediatR;
using SimpleBankingControlPanel.Application.Client.Dto;

namespace SimpleBankingControlPanel.Application.Client.Queries.GetClient;

public class GetClientQuery : IRequest<ClientDto?>
{
    public Guid Id { get; set; }
}