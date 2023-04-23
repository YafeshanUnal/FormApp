using Core.Application.Features.Commands.Form;
using Core.Application.Features.Commands.User;
using Core.Application.Features.Queries.Form;
using Core.Application.Wrappers.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Base;

namespace Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FormController : BaseController
    {
        public FormController(IMediator mediator)
            : base(mediator) { }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFormCommand command)
        {
            var result = await mediator.Send(command);
            if (result.Succeeded)
                return Ok(result);

            return NotFound(Result.Problem(result.Info));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await mediator.Send(new GetAllFormQuery());
            if (result.Succeeded)
                return Ok(result);

            return NotFound(Result.Problem(result.Info));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await mediator.Send(new GetFormByIdQuery(id));
            if (result.Succeeded)
                return Ok(result);

            return NotFound(Result.Problem(result.Info));
        }
    }
}
