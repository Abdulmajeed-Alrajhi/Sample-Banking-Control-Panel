using MediatR;
using SimpleBankingControlPanel.Application.Client.Dto;
using SimpleBankingControlPanel.Shared;

namespace SimpleBankingControlPanel.Application.Client.Queries.ListClients;

public class ListClientsQuery : IRequest<PaginatedList<ClientDto>>
{
    public string? FilterBy { get; set; }
    public string? Filter { get; set; }

    public string? SortBy { get; set; }
    public string? SortDirection { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}