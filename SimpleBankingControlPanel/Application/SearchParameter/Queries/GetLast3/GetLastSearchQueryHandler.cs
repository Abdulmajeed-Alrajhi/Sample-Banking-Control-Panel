using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleBankingControlPanel.Application.SearchParameter.Dto;
using SimpleBankingControlPanel.Data;

namespace SimpleBankingControlPanel.Application.SearchParameter.Queries.GetLast3;

public class GetLastSearchQueryHandler : IRequest<List<SearchParameterDto>>
{
    private readonly ApplicationDbContext _context;

    public GetLastSearchQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<SearchParameterDto>> Handle(GetLastSearchQuery request, CancellationToken cancellationToken)
    {
        var searchParameters = await _context.SearchParameters
            .OrderByDescending(sp => sp.SearchedAt)
            .Take(request.Count)
            .ProjectToType<SearchParameterDto>()
            .ToListAsync(cancellationToken);

        return searchParameters;
    }
}