using MediatR;
using SimpleBankingControlPanel.Data;
using SimpleBankingControlPanel.Shared;

namespace SimpleBankingControlPanel.Application.SearchParameter.Commands.CreateSearchParameter;

public class CreateSearchParameterCommandHandler : IRequestHandler<CreateSearchParameterCommand, Result>
{
    private readonly ApplicationDbContext _context;

    public CreateSearchParameterCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result> Handle(CreateSearchParameterCommand request, CancellationToken cancellationToken)
    {
        var searchParameter = new Domain.SearchParameter
        {
            Id = Guid.NewGuid(),
            Parameter = request.Parameter,
            SearchedAt = DateTime.UtcNow
        };

        _context.SearchParameters.Add(searchParameter);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}