﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using SofthouseMediatR.Commands;
using SofthouseMediatR.Dto;
using SofthouseMediatR.Queries;

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
    public async Task<IActionResult> Create([FromBody] CreateCarRequest request)
    {
        if (await _mediator.Send(new CreateCarCommand(request)) is { } response)
        {
            return Created(nameof(Create), response);
        }

        return BadRequest();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        if (await _mediator.Send(new GetCarQuery(id)) is { } response)
        {
            return Ok(response);
        }

        return NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllCarsQuery();
        var response = await _mediator.Send(query);

        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCarRequest request)
    {
        if (await _mediator.Send(new UpdateCarCommand(id, request)) is { } response)
        {
            return Ok(response);
        }

        return BadRequest();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteCarCommand(id);
        var response = await _mediator.Send(command);

        if (response != Guid.Empty)
        {
            return Ok(id);
        }

        return BadRequest();
    }
}