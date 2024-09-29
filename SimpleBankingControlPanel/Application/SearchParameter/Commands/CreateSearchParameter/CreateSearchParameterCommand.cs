using MediatR;
using SimpleBankingControlPanel.Shared;

namespace SimpleBankingControlPanel.Application.SearchParameter.Commands.CreateSearchParameter;

public class CreateSearchParameterCommand : IRequest<Result>
{
    public CreateSearchParameterCommand(string parameter)
    {
        Parameter = parameter;
    }

    public string Parameter { get; set; }
}