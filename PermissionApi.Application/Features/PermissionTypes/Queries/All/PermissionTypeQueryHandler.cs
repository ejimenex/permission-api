using AutoMapper;
using PermissionApi.Domain.Entities;

namespace PermissionApi.Application.Features.PermissionTypes.Queries.All
{
    public class PermissionTypeQueryHandler : IRequestHandler<PermissionTypeQuery, List<PermissinTypeVm>>
    {
        private readonly IMapper mapper;
        private readonly IAsyncRepository<PermissionType> permissionTypeRepository;
        public PermissionTypeQueryHandler(IMapper mapper, IAsyncRepository<PermissionType> permissionTypeRepository)
        {
            this.mapper = mapper;
            this.permissionTypeRepository = permissionTypeRepository;
        }

        public async Task<List<PermissinTypeVm>> Handle(PermissionTypeQuery request, CancellationToken cancellationToken)
        {
            var permission = await permissionTypeRepository.ListAllAsync();
            return mapper.Map<List<PermissinTypeVm>>(permission);
        }
    }
}
