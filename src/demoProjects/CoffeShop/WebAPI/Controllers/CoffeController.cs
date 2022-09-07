using Application.Features.Coffes.Commands.CreateCoffe;
using Application.Features.Coffes.Commands.DeleteCoffe;
using Application.Features.Coffes.Commands.UpdateCoffe;
using Application.Features.Coffes.Dtos;
using Application.Features.Coffes.Dtos.Coffes;
using Application.Features.Coffes.Models.Coffe;
using Application.Features.Coffes.Queries.GetByIdCoffe;
using Application.Features.Coffes.Queries.GetListCoffe;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;



[Route("api/[controller]")]
[ApiController]
public class CoffeController :ControllerBase
{
    private readonly IMediator _mediator;
    public CoffeController(IMediator mediator)
    {
        _mediator = mediator; 

    }
    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] CreateCoffeCommand createCoffeCommand)
    {
        CreatedCoffeDto result = await _mediator.Send(createCoffeCommand);
        return Created("", result);
    }
    [HttpGet("getlist")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCoffeQuary getListCoffeQuary = new() { PageRequest = pageRequest };
        CoffeListModel result = await _mediator.Send(getListCoffeQuary);
        return Ok(result);
    }

    [HttpDelete("Id")]
    public async Task<IActionResult> Delete([FromBody] DeleteCoffeCommand deleteCoffeCommand)
    {
        DeletedCoffeDto result = await _mediator.Send(deleteCoffeCommand);
        return Ok(result);
    }
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdCoffeQuery getByIdIdBrandQuery)
    {
        CoffeGetByIdDto coffeGetByIdDto = await _mediator.Send(getByIdIdBrandQuery);
        return Ok(coffeGetByIdDto);
    }
    [HttpPost("update")]
    public async Task<IActionResult> Update([FromQuery] UpdateCoffeCommand updateCoffeCommand)
    {
        UpdatedCoffeDto result = await _mediator.Send(updateCoffeCommand);
        return Ok(result);

    }
}
