using MediatR;
using SimpleBankingControlPanel.Application.SearchParameter.Dto;

namespace SimpleBankingControlPanel.Application.SearchParameter.Queries.GetLast3;

public class GetLastSearchQuery(int count) : IRequest<List<SearchParameterDto>>
{
    public int Count { get; } = count;
}