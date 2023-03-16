namespace PermissionApi.Application.Features.Permissions.Command.DeletePermission
{
    public class DeletePermissionCommand : IRequest
    {
        public int Id { get; set; }
    }
}
