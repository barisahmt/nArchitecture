using Application.Features.Coffes.Commands.CreateCoffe;
using Application.Features.Coffes.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoffeController : BaseController
{
    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] CreateCoffeCommand createCoffeCommand)
    {
        CreatedCoffeDto result = await Mediator.Send(createCoffeCommand);
        return Created("", result);
    }
}
