namespace N5.Permissions.Core.Entities
{
    public class Permission: EntityBase
    {
        public virtual PermissionType PermissionType { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public DateTime PermissionDate { get; set; }
    }
}