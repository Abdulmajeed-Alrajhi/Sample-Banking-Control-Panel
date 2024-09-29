using MediatR;
using SimpleBankingControlPanel.Data;
using SimpleBankingControlPanel.Domain;
using SimpleBankingControlPanel.Shared;

namespace SimpleBankingControlPanel.Application.Client.Commands.CreateClient;

public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Result>
{
    private readonly ApplicationDbContext _context;

    public CreateClientCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var client = new Domain.Client
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            PersonalId = request.PersonalId,
            ProfilePhoto = request.ProfilePhoto,
            MobileNumber = request.MobileNumber,
            Sex = request.Sex,
            Address = new Address
            {
                Country = request.Address.Country,
                City = request.Address.City,
                Street = request.Address.Street,
                ZipCode = request.Address.ZipCode
            },
            Accounts = request.Accounts.Select(a => new Account
            {
                AccountNumber = a.AccountNumber,
                Balance = a.Balance
            }).ToList(),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Clients.Add(client);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}