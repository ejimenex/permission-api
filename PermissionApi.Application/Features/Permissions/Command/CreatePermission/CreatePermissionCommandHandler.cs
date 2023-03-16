using AutoMapper;
using PermissionApi.Application.Exceptions;
using PermissionApi.Domain.Entities;

namespace PermissionApi.Application.Features.Permissions.Command.CreatePermission
{
    public class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, CreatePermissionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Permission> permissionRepository;
        public CreatePermissionCommandHandler(IMapper mapper, IAsyncRepository<Permission> _permissionRepository)
        {
            _mapper = mapper;
            permissionRepository = _permissionRepository;
        }

        public async Task<CreatePermissionResponse> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
        {
            var permissionResponse = new CreatePermissionResponse();
            var validator = new CreatePermissionValidation();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                permissionResponse.Success = false;
                throw new FriendlyException(validationResult);
            }
            if (permissionResponse.Success)
            {
                var permission = _mapper.Map<Permission>(request);
                permission = await permissionRepository.AddAsync(permission);
                permissionResponse.Permission = _mapper.Map<CreatePermissionDto>(permission);
            }
            return permissionResponse;
        }
    }
}
