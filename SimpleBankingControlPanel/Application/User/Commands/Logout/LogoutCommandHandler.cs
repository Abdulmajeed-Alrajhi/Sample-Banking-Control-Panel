using MediatR;
using Microsoft.AspNetCore.Identity;

namespace SimpleBankingControlPanel.Application.User.Commands.Logout;

public class LogoutCommandHandler : IRequestHandler<LogoutCommand>
{
    private readonly SignInManager<Domain.User> _signInManager;

    public LogoutCommandHandler(SignInManager<Domain.User> signInManager)
    {
        _signInManager = signInManager;
    }

    Task IRequestHandler<LogoutCommand>.Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        await _signInManager.SignOutAsync();
        return Unit.Value;
    }
}