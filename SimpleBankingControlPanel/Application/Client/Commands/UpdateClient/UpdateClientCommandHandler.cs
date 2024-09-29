using MediatR;
using SimpleBankingControlPanel.Data;
using SimpleBankingControlPanel.Domain;
using SimpleBankingControlPanel.Shared;

namespace SimpleBankingControlPanel.Application.Client.Commands.UpdateClient;

public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Result>
{
    private readonly ApplicationDbContext _context;

    public UpdateClientCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        var client = await _context.Clients.FindAsync(request.Id);

        if (client == null) return Result.Failure("Client not found");

        client.Email = request.Email;
        client.FirstName = request.FirstName;
        client.LastName = request.LastName;
        client.PersonalId = request.PersonalId;
        client.ProfilePhoto = request.ProfilePhoto;
        client.MobileNumber = request.MobileNumber;
        client.Sex = request.Sex;
        client.Address = new Address
        {
            Country = request.Address.Country,
            City = request.Address.City,
            Street = request.Address.Street,
            ZipCode = request.Address.ZipCode
        };
        client.Accounts = request.Accounts.Select(a => new Account
        {
            AccountNumber = a.AccountNumber,
            Balance = a.Balance
        }).ToList();
        client.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}