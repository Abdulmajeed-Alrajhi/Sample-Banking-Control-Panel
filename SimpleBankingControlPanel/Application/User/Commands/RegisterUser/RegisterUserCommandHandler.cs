using MediatR;
using Microsoft.AspNetCore.Identity;
using SimpleBankingControlPanel.Shared;

namespace SimpleBankingControlPanel.Application.User.Commands.RegisterUser;

public class
    RegisterUserCommandHandler
    : IRequestHandler<RegisterUserCommand, Result>
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<Domain.User> _userManager;

    public RegisterUserCommandHandler(
        UserManager<Domain.User> userManager,
        RoleManager<IdentityRole> roleManager
    )
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<Result>
        Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user =
            new Domain.User
            {
                UserName = request.Email,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            if (!await _roleManager.RoleExistsAsync(request.Role))
                await _roleManager.CreateAsync(new IdentityRole(request.Role));

            await _userManager.AddToRoleAsync(user, request.Role);
            return Result.Success();
        }

        return Result
            .Failure(string.Join(", ", result.Errors.Select(e => e.Description)));
    }
}