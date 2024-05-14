using FluentValidation;

namespace FuDever.Application.Features.Department.UpdateDepartmentByDepartmentId;

/// <summary>
///     Update department by department id request validator.
/// </summary>
public sealed class UpdateDepartmentByDepartmentIdRequestValidator
    : AbstractValidator<UpdateDepartmentByDepartmentIdRequest>
{
    public UpdateDepartmentByDepartmentIdRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.DepartmentId)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty();

        RuleFor(expression: request => request.NewDepartmentName)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty()
            .MaximumLength(maximumLength: Domain.Entities.Department.Metadata.Name.MaxLength)
            .MinimumLength(minimumLength: Domain.Entities.Department.Metadata.Name.MinLength);
    }
}
