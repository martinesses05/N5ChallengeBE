using Microsoft.EntityFrameworkCore;
using N5.Permissions.Core.Entities;

namespace N5.Permissions.Core.Contracts
{
    public interface IAppDBContext
    {
        DbSet<Permission> Permissions { get; }
        DbSet<PermissionType> PermissionTypes { get; }
        void Save();
    }
}