using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleBankingControlPanel.Application.Client.Dto;
using SimpleBankingControlPanel.Data;

namespace SimpleBankingControlPanel.Application.Client.Queries.GetClient;

public class GetClientQueryHandler : IRequestHandler<GetClientQuery, ClientDto?>
{
    private readonly ApplicationDbContext _context;

    public GetClientQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ClientDto?> Handle(GetClientQuery request, CancellationToken cancellationToken)
    {
        var client = await _context.Clients
            .Include(c => c.Address)
            .Include(c => c.Accounts)
            .ProjectToType<ClientDto>()
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

        return client;
    }
}