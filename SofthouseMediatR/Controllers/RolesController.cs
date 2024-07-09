using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SofthouseMediatR.Commands.Identity.Role;
using SofthouseMediatR.Dto.Identity.Role;
using SofthouseMediatR.Queries.Identity.Role;

namespace SofthouseMediatR.Controllers;

[ApiController]
[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
[Produces("application/json")]
public class RolesController : ControllerBase
{
    private readonly IMediator _mediator;

    public RolesController(IMediator mediator)
    {
        _mediator = mediator;
    }
        
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetRoleByIdQuery(id), cancellationToken);
        
        return Ok(response);
    }
        
    [HttpGet("{name}")]
    public async Task<IActionResult> GetByName(string name, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetRoleByNameQuery(name), cancellationToken);
        
        return Ok(response);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetRolesQuery(), cancellationToken);
        
        return Ok(response);
    }
        
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRoleRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new CreateRoleCommand(request.Name), cancellationToken);
        
        return Created(nameof(Create), response);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(string id, [FromBody] UpdateRoleRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new UpdateRoleCommand(id, request.Name), cancellationToken);

        return Ok(response);
    }
        
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteRoleCommand(id), cancellationToken);

        return NoContent();
    }
}
