using FluentValidation;

namespace PermissionApi.Application.Features.Permissions.Command.UpdatePermission
{
    public class UpdatePermissionValidation : AbstractValidator<UpdatePermissionCommand>
    {
        public UpdatePermissionValidation()
        {
            RuleFor(p => p.EmployeeLastName).NotEmpty().WithMessage("{PropertyName} is required").NotNull();
            RuleFor(p => p.EmployeeName).NotEmpty().WithMessage("{PropertyName} is required").NotNull();
            RuleFor(p => p.PermissionTypeId).NotEmpty().NotEqual(0).WithMessage("{PropertyName} is required").NotNull();
        }
    }
}
