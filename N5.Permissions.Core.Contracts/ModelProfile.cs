using AutoMapper;

namespace N5.Permissions.Core.Contracts
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {            
            CreateMap<Entities.Permission, DTOs.PermissionDTO>();
            CreateMap<Entities.PermissionType, DTOs.PermissionTypeDTO>();
        }
    }
}
