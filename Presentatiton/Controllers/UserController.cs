using Core.Application.Features.Commands.User;
using Core.Application.Features.Queries.User;
using Core.Application.Wrappers.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Base;

namespace Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : BaseController
    {
        public UserController(IMediator mediator)
            : base(mediator) { }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var result = await mediator.Send(command);
            if (result.Succeeded)
                return Ok(result);

            return NotFound(Result.Problem(result.Info));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await mediator.Send(new GetAllUserQuery());
            if (result.Succeeded)
                return Ok(result);

            return NotFound(Result.Problem(result.Info));
        }

        // Check if user exists
    }
}
