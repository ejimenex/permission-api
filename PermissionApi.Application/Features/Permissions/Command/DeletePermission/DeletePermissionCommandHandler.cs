using PermissionApi.Domain.Entities;

namespace PermissionApi.Application.Features.Permissions.Command.DeletePermission
{
    public class DeletePermissionCommandHandler : IRequestHandler<DeletePermissionCommand>
    {
        private readonly IAsyncRepository<Permission> permissionRepository;
        public DeletePermissionCommandHandler(IAsyncRepository<Permission> asyncRepository)
        {
            permissionRepository = asyncRepository;
        }

        public async Task<Unit> Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
        {
            await permissionRepository.DeleteAsync(request.Id);
            return Unit.Value;
        }


    }
}
