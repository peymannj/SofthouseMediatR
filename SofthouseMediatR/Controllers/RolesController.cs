using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SofthouseMediatR.Commands.Identity.Role;
using SofthouseMediatR.Queries.Identity.Role;

namespace SofthouseMediatR.Controllers
{
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
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(string id)
        {
            var response = await _mediator.Send(new GetRoleByIdQuery(id));

            return Ok(response);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetRoleByName(string name)
        {
            var response = await _mediator.Send(new GetRoleByNameQuery(name));

            return Ok(response);
        }
    
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var response = await _mediator.Send(new GetRolesQuery());

            return Ok(response);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] string name)
        {
            var response = await _mediator.Send(new CreateRoleCommand(name));

            return Created(nameof(Create), response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, string name)
        {
            var response = await _mediator.Send(new UpdateRoleCommand(id, name));

            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _mediator.Send(new DeleteRoleCommand(id));

            return NoContent();
        }
    }
}
