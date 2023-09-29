using Encuesta.Backend.Application.Commands.Usuario.Login;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Encuesta.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator mediator;
        public UsuarioController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUsuarioCommand command)
        {
            string token = await mediator.Send(command);
            return Ok(new { Token = token });
        }
    }
}
