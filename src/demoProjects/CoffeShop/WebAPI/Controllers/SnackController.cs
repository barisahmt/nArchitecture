using Application.Features.Coffes.Commands.CreateSnack;
using Application.Features.Snacks.Commands.DeleteSnack;
using Application.Features.Snacks.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnackController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SnackController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateSnackCommand createSnackCommand)
        {
            CreatedSnackDto result = await _mediator.Send(createSnackCommand);
            return Created("", result);
        }
        [HttpPost("delete")]
        public async Task<IActionResult> Add([FromBody] DeleteSnackCommand deleteSnackCommand)
        {
            DeletedSnackDto result = await _mediator.Send(deleteSnackCommand);
            return Created("", result);
        }
    }
}
