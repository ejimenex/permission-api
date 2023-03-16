using AutoMapper;
using PermissionApi.Application.Features.Permissions.Command.CreatePermission;
using PermissionApi.Application.Features.Permissions.Command.UpdatePermission;
using PermissionApi.Application.Features.Permissions.Queries.GetAll;
using PermissionApi.Application.Features.Permissions.Queries.GetById;
using PermissionApi.Domain.Entities;

namespace PermissionApi.Application.Profiles
{
    public class PermissionProfile : Profile
    {
        public PermissionProfile()
        {
            CreateMap<Permission, CreatePermissionDto>().ReverseMap();
            CreateMap<Permission, CreatePermissionCommand>().ReverseMap();

            CreateMap<Permission, GetAllPermissionVm>()
                 .ForMember(c => c.PermissionTypeDescription, opt => opt.MapFrom(c => c.PermissionType.Description))
            .ForMember(c => c.PermissionDate, opt => opt.MapFrom(c => c.PermissionDate.ToString("dd-MM-yyyy")));

            CreateMap<Permission, UpdatePermissionCommand>().ReverseMap();

            CreateMap<Permission, PermissionByIdVm>()
                .ForMember(c => c.PermissionTypeDescription, opt => opt.MapFrom(c => c.PermissionType.Description));
        }
    }
}
