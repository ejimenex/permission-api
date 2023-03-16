using PermissionApi.Application.Response;

namespace PermissionApi.Application.Features.Permissions.Command.CreatePermission
{
    public class CreatePermissionResponse : BaseResponse
    {
        public CreatePermissionResponse() : base() { }

        public CreatePermissionDto Permission { get; set; } = default;
    }
}
