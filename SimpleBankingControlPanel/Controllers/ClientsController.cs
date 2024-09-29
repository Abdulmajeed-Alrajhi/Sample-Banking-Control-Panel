using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleBankingControlPanel.Application.Client.Commands.CreateClient;
using SimpleBankingControlPanel.Application.Client.Commands.DeleteClient;
using SimpleBankingControlPanel.Application.Client.Commands.UpdateClient;
using SimpleBankingControlPanel.Application.Client.Dto;
using SimpleBankingControlPanel.Application.Client.Queries.GetClient;
using SimpleBankingControlPanel.Application.Client.Queries.ListClients;
using SimpleBankingControlPanel.Application.SearchParameter.Dto;
using SimpleBankingControlPanel.Application.SearchParameter.Queries.GetLast3;

namespace SimpleBankingControlPanel.Controllers;

/// <summary>
/// Controller responsible for handling client-related actions.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="ClientsController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator instance for sending commands and queries.</param>
    public ClientsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Creates a new client.
    /// </summary>
    /// <param name="command">The command containing client creation details.</param>
    /// <returns>An indicating the result of the creation operation.</returns>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateClient(CreateClientCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result.Error);
    }

    /// <summary>
    /// Updates an existing client.
    /// </summary>
    /// <param name="id">The ID of the client to update.</param>
    /// <param name="command">The command containing client update details.</param>
    /// <returns>An indicating the result of the update operation.</returns>
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateClient(Guid id, UpdateClientCommand command)
    {
        if (id != command.Id) return BadRequest("Client ID mismatch");

        var result = await _mediator.Send(command);
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result.Error);
    }

    /// <summary>
    /// Deletes an existing client.
    /// </summary>
    /// <param name="id">The ID of the client to delete.</param>
    /// <returns>An indicating the result of the deletion operation.</returns>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteClient(Guid id)
    {
        var result = await _mediator.Send(new DeleteClientCommand { Id = id });
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result.Error);
    }

    /// <summary>
    /// Retrieves a client by ID.
    /// </summary>
    /// <param name="id">The ID of the client to retrieve.</param>
    /// <returns>An <see cref="ClientDto"/> containing the client details.</returns>
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetClient(Guid id)
    {
        var client = await _mediator.Send(new GetClientQuery { Id = id });
        if (client == null) return NotFound();

        return Ok(client);
    }

    /// <summary>
    /// Retrieves a list of clients based on the specified query parameters.
    /// </summary>
    /// <param name="query">The query parameters for listing clients.</param>
    /// <returns>An <see cref="ClientDto"/> containing the list of clients.</returns>
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetClients([FromQuery] ListClientsQuery query)
    {
        var clients = await _mediator.Send(query);
        return Ok(clients);
    }

    /// <summary>
    /// Retrieves the last 3 search parameters as suggestions.
    /// </summary>
    /// <returns>An <see cref="SearchParameterDto"/> containing the search suggestions.</returns>
    [HttpGet("[action]")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetSearchSuggestions()
    {
        var searchSuggestions = await _mediator.Send(new GetLastSearchQuery(3));
        return Ok(searchSuggestions);
    }
}