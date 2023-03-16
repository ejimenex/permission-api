using FluentValidation;

namespace PermissionApi.Application.Features.Permissions.Command.CreatePermission
{
    public class CreatePermissionValidation : AbstractValidator<CreatePermissionCommand>
    {
        public CreatePermissionValidation()
        {
            RuleFor(p => p.PermissionTypeId).NotEqual(0).WithMessage("{PropertyName} is required");
            RuleFor(p => p.EmployeeLastName).NotEmpty().NotNull().WithMessage("{PropertyName} is required");
            RuleFor(p => p.PermissionDate).NotEmpty().NotNull().WithMessage("{PropertyName} is required");
            RuleFor(p => p.EmployeeName).NotEmpty().WithMessage("{PropertyName} is required").NotNull().MaximumLength(10).WithMessage("{PropertyName} must not exceed 10 characters");
        }
    }
}
