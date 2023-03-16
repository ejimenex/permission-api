namespace PermissionApi.Application.Features.Permissions.Queries.GetAll
{
    public class GetAllPermissionVm
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public int PermissionTypeId { get; set; }
        public string PermissionTypeDescription { get; set; }
        public string PermissionDate { get; set; }
    }
}
