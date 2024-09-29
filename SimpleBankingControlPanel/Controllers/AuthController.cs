using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleBankingControlPanel.Application.User.Commands.Login;
using SimpleBankingControlPanel.Application.User.Commands.Logout;

namespace SimpleBankingControlPanel.Controllers;

/// <summary>
/// Controller responsible for handling authentication-related actions.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator instance for sending commands.</param>
    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Handles user login requests.
    /// </summary>
    /// <param name="command">The login command containing user credentials.</param>
    /// <returns>An <see cref="IActionResult"/> indicating the result of the login operation.</returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    /// <summary>
    /// Handles user logout requests.
    /// </summary>
    /// <returns>An <see cref="IActionResult"/> indicating the result of the logout operation.</returns>
    [HttpPost("logout")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await _mediator.Send(new LogoutCommand());
        return Ok(new { message = "Logged out successfully" });
    }
}