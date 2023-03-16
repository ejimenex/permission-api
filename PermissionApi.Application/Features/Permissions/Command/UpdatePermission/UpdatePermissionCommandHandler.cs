using AutoMapper;
using PermissionApi.Application.Exceptions;
using PermissionApi.Domain.Entities;

namespace PermissionApi.Application.Features.Permissions.Command.UpdatePermission
{
    public class UpdatePermissionCommandHandler : IRequestHandler<UpdatePermissionCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Permission> permissionRepository;
        public UpdatePermissionCommandHandler(IMapper mapper, IAsyncRepository<Permission> asyncRepository)
        {
            _mapper = mapper;
            permissionRepository = asyncRepository;

        }

        public async Task<Unit> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdatePermissionValidation();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                throw new FriendlyException(validationResult);
            }
            var permissionToUpdate = await permissionRepository.GetByIdAsync(request.Id);
            _mapper.Map(request, permissionToUpdate, typeof(UpdatePermissionCommand), typeof(Permission));
            await permissionRepository.UpdateAsync(permissionToUpdate);
            return Unit.Value;
        }
    }
}
