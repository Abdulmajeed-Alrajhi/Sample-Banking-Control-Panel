using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleBankingControlPanel.Application.Client.Dto;
using SimpleBankingControlPanel.Application.SearchParameter.Commands.CreateSearchParameter;
using SimpleBankingControlPanel.Data;
using SimpleBankingControlPanel.Shared;

namespace SimpleBankingControlPanel.Application.Client.Queries.ListClients;

public class ListClientsQueryHandler : IRequestHandler<ListClientsQuery, PaginatedList<ClientDto>>
{
    private readonly ApplicationDbContext _context;
    private readonly IMediator _mediator;

    public ListClientsQueryHandler(ApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<PaginatedList<ClientDto>> Handle(ListClientsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Clients.AsQueryable();

        if (!string.IsNullOrEmpty(request.FilterBy) && !string.IsNullOrEmpty(request.Filter))
        {
            query = request.FilterBy switch
            {
                "FirstName" => query.Where(c => c.FirstName.Contains(request.Filter)),
                "LastName" => query.Where(c => c.LastName.Contains(request.Filter)),
                _ => query
            };

            await _mediator.Send(new CreateSearchParameterCommand(request.FilterBy + ":" + request.Filter),
                cancellationToken);
        }

        if (!string.IsNullOrEmpty(request.SortBy) && !string.IsNullOrEmpty(request.SortDirection))
            query = request.SortBy switch
            {
                "FirstName" => request.SortDirection == "asc"
                    ? query.OrderBy(c => c.FirstName)
                    : query.OrderByDescending(c => c.FirstName),
                "LastName" => request.SortDirection == "asc"
                    ? query.OrderBy(c => c.LastName)
                    : query.OrderByDescending(c => c.LastName),
                _ => query.OrderBy(c => c.CreatedAt)
            };

        var clients = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ProjectToType<ClientDto>()
            .ToListAsync(cancellationToken);

        var totalCount = await query.CountAsync(cancellationToken);

        return new PaginatedList<ClientDto>
        {
            Items = clients,
            TotalCount = totalCount,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize
        };
    }
}