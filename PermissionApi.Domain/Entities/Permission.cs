using PermissionApi.Domain.Common;

namespace PermissionApi.Domain.Entities
{
    public class Permission : BaseId
    {
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public int PermissionTypeId { get; set; }
        public virtual PermissionType PermissionType { get; set; }
        public DateTime PermissionDate { get; set; }
    }
}
