using MediatR;
using SimpleBankingControlPanel.Shared;

namespace SimpleBankingControlPanel.Application.User.Commands.RegisterUser;

public class RegisterUserCommand : IRequest<Result>
{
    public string Email { get; set; }

    public string Password { get; set; }

    public string Role { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
}