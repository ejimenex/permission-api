using AutoMapper;
using PermissionApi.Domain.Entities;

namespace PermissionApi.Application.Features.Permissions.Queries.GetAll
{
    public class GetAllPermissionQueryHandler : IRequestHandler<GetAllPermissionQuery, List<GetAllPermissionVm>>
    {
        private readonly IMapper mapper;
        private readonly IAsyncRepository<Permission> asyncRepository;
        public GetAllPermissionQueryHandler(IMapper mapper, IAsyncRepository<Permission> _asyncRepository)
        {
            asyncRepository = _asyncRepository;
            this.mapper = mapper;
        }

        public async Task<List<GetAllPermissionVm>> Handle(GetAllPermissionQuery request, CancellationToken cancellationToken)
        {
            var permission = await asyncRepository.ListAllAsync();
            return mapper.Map<List<GetAllPermissionVm>>(permission);
        }
    }
}
