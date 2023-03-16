using AutoMapper;
using PermissionApi.Domain.Entities;

namespace PermissionApi.Application.Features.Permissions.Queries.GetById
{
    public class PermissionByIdQueryHandler : IRequestHandler<PermissionByIdQuery, PermissionByIdVm>
    {
        private readonly IMapper mapper;
        private readonly IAsyncRepository<Permission> repositoryRepository;
        public PermissionByIdQueryHandler(IMapper mapper, IAsyncRepository<Permission> asyncRepository)
        {
            this.mapper = mapper;
            repositoryRepository = asyncRepository;
        }

        public async Task<PermissionByIdVm> Handle(PermissionByIdQuery request, CancellationToken cancellationToken)
        {
            var permission = await repositoryRepository.GetByIdAsync(request.Id);
            return mapper.Map<PermissionByIdVm>(permission);
        }
    }
}
