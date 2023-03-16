using MediatR;
using Microsoft.AspNetCore.Mvc;
using PermissionApi.Application.Features.Permissions.Command.CreatePermission;
using PermissionApi.Application.Features.Permissions.Command.DeletePermission;
using PermissionApi.Application.Features.Permissions.Command.UpdatePermission;
using PermissionApi.Application.Features.Permissions.Queries.GetAll;
using PermissionApi.Application.Features.Permissions.Queries.GetById;

namespace PermissionsApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IMediator mediator;
        public PermissionController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("all")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetAllPermissionVm>>> GetAllPermission()
        {
            var dots = await mediator.Send(new GetAllPermissionQuery());
            return Ok(dots);
        }
        [HttpPost]
        public async Task<ActionResult<CreatePermissionResponse>> Create(CreatePermissionCommand createPermissionCommand)
        {
            var response = await mediator.Send(createPermissionCommand);
            return Ok(response);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<PermissionByIdVm>> GetById(int Id)
        {
            return Ok(await mediator.Send(new PermissionByIdQuery() { Id = Id }));
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdatePermissionCommand updatePermissionCommand)
        {
            await mediator.Send(updatePermissionCommand);
            return NoContent();
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var deletePermissionCommand = new DeletePermissionCommand() { Id = id };
            await mediator.Send(deletePermissionCommand);
            return NoContent();
        }

    }
}
