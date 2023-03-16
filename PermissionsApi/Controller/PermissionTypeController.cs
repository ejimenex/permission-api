using MediatR;
using Microsoft.AspNetCore.Mvc;
using PermissionApi.Application.Features.PermissionTypes.Queries.All;

namespace PermissionsApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionTypeController : ControllerBase
    {
        private readonly IMediator mediator;
        public PermissionTypeController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("all")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PermissinTypeVm>>> GetAllPermissionType()
        {
            var dots = await mediator.Send(new PermissionTypeQuery());
            return Ok(dots);
        }
    }
}
