using AutoMapper;
using PermissionApi.Application.Features.PermissionTypes.Queries.All;
using PermissionApi.Domain.Entities;

namespace PermissionApi.Application.Profiles
{
    public class PermissionTypeProfile : Profile
    {
        public PermissionTypeProfile()
        {
            CreateMap<PermissionType, PermissinTypeVm>();
        }
    }
}
