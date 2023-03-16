namespace PermissionApi.Application.Features.Permissions.Queries.GetById
{
    public class PermissionByIdQuery : IRequest<PermissionByIdVm>
    {
        public int Id { get; set; }
    }
}
