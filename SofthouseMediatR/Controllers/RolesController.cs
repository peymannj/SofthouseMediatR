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
    public async Task<IActionResult> GetById(string id)
    {
        var response = await _mediator.Send(new GetRoleByIdQuery(id));
        
        return Ok(response);
    }
        
    [HttpGet("{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        var response = await _mediator.Send(new GetRoleByNameQuery(name));
        
        return Ok(response);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetRolesQuery());
        
        return Ok(response);
    }
        
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRoleRequest request)
    {
        var response = await _mediator.Send(new CreateRoleCommand(request.Name));
        
        return Created(nameof(Create), response);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(string id, [FromBody] UpdateRoleRequest request)
    {
        var response = await _mediator.Send(new UpdateRoleCommand(id, request.Name));

        return Ok(response);
    }
        
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _mediator.Send(new DeleteRoleCommand(id));

        return NoContent();
    }
}
