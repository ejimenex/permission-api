namespace PermissionApi.Application.Features.Permissions.Command.CreatePermission
{
    public class CreatePermissionCommand : IRequest<CreatePermissionResponse>
    {
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public int PermissionTypeId { get; set; }
        public DateTime PermissionDate { get; set; }
    }
}
