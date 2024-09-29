using MediatR;
using SimpleBankingControlPanel.Shared;

namespace SimpleBankingControlPanel.Application.Client.Commands.DeleteClient;

public class DeleteClientCommand : IRequest<Result>
{
    public Guid Id { get; set; }
}