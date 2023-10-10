using N5.Permissions.Core.DTOs;
using N5.Permissions.Core.DTOs.Common;
using N5.Permissions.Core.DTOs.Filters;

namespace N5.Permissions.Core.Contracts
{
    // TODO: create a base interface for generic CRUD operations
    public interface IPermissionsBL
    {
        PermissionDTO GetById(int id);
        PagedListResponse<PermissionDTO> Get(PermissionsFilter filter);
        PermissionDTO Create(PermissionDTO dto);
        PermissionDTO Update(PermissionDTO dto);
        void Delete(int id);
    }
}