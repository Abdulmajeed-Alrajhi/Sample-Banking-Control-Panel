using MediatR;
using SimpleBankingControlPanel.Data;
using SimpleBankingControlPanel.Shared;

namespace SimpleBankingControlPanel.Application.Client.Commands.DeleteClient;

public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, Result>
{
    private readonly ApplicationDbContext _context;

    public DeleteClientCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        var client = await _context.Clients.FindAsync(request.Id);

        if (client == null) return Result.Failure("Client not found");

        _context.Clients.Remove(client);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}