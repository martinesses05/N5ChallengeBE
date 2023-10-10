using N5.Permissions.Core.DTOs;
using N5.Permissions.Core.DTOs.Common;
using N5.Permissions.Core.DTOs.Filters;

namespace N5.Permissions.Core.Contracts
{
    // TODO: create a base interface for generic CRUD operations
    public interface IPermissionTypesBL
    {
        PermissionTypeDTO GetById(int id);
        PagedListResponse<PermissionTypeDTO> Get(PermissionTypesFilter filter);
        PermissionTypeDTO Create(PermissionTypeDTO dto);
        PermissionTypeDTO Update(PermissionTypeDTO dto);
        void Delete(int id);
    }
}