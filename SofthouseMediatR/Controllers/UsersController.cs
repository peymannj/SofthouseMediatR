using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SofthouseMediatR.Commands.Identity.User;
using SofthouseMediatR.Dto.Identity.User;
using SofthouseMediatR.Queries.Identity.User;

namespace SofthouseMediatR.Controllers;

[ApiController]
[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
[Produces("application/json")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
	    _mediator = mediator;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(string id)
    {
	    var response = await _mediator.Send(new GetUserQuery(id));

	    return Ok(response);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
	    var response = await _mediator.Send(new GetUsersQuery());

	    return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
    {
	    var response = await _mediator.Send(new CreateUserCommand(request));

	    return Created(nameof(Create), response);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(string id, [FromBody] UpdateUserRequest request)
    {
	    var response = await _mediator.Send(new UpdateUserCommand(id, request));

	    return Ok(response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(string id)
    {
	    await _mediator.Send(new DeleteUserCommand(id));

	    return NoContent() ;
    }
    
    [HttpPost("{id:guid}/role")]
    public async Task<IActionResult> AddUserToRole([FromBody] AddToRoleRequest request)
    {
	    await _mediator.Send(new AddUserToRoleCommand(request.UserId, request.Role));

	    return Ok();
    }
    
    [HttpDelete("{id:guid}/role")]
    public async Task<IActionResult> RemoveUserFromRole([FromBody] RemoveFromRoleRequest request)
    {
	    await _mediator.Send(new RemoveUserFromRoleCommand(request.UserId, request.Role));

	    return Ok();
    }
}
