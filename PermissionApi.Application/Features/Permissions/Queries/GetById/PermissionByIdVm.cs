namespace PermissionApi.Application.Features.Permissions.Queries.GetById
{
    public class PermissionByIdVm
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public int PermissionTypeId { get; set; }
        public string PermissionTypeDescription { get; set; }
        public DateTime PermissionDate { get; set; }
    }
}
