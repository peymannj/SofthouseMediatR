using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SofthouseMediatR.Commands.Car;
using SofthouseMediatR.Dto.Car;
using SofthouseMediatR.Queries.Car;

namespace SofthouseMediatR.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class CarsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CarsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Authorize(Roles= "Admin")]
    public async Task<IActionResult> Create([FromBody] CreateCarRequest request, CancellationToken cancellationToken)
    {
        if (await _mediator.Send(new CreateCarCommand(request), cancellationToken) is { } response)
        {
            return Created(nameof(Create), response);
        }

        return BadRequest();
    }

    [HttpGet("{id:guid}")]
    [Authorize(Roles= "Admin")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        if (await _mediator.Send(new GetCarQuery(id), cancellationToken) is { } response)
        {
            return Ok(response);
        }

        return NotFound();
    }

    [HttpGet]
    [Authorize(Roles = "Admin, User")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllCarsQuery(), cancellationToken);

        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles= "Admin")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCarRequest request, CancellationToken cancellationToken)
    {
        if (await _mediator.Send(new UpdateCarCommand(id, request), cancellationToken) is { } response)
        {
            return Ok(response);
        }

        return BadRequest();
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles= "Admin")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new DeleteCarCommand(id), cancellationToken);

        if (response != Guid.Empty)
        {
            return Ok(id);
        }

        return BadRequest();
    }
}
