namespace N5.Permissions.Core.DTOs
{
    public class PermissionDTO
    {
        public int Id { get; set; }
        public int PermissionTypeId { get; set; }
        public string PermissionTypeDescription { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public DateTime PermissionDate { get; set; }
    }
}