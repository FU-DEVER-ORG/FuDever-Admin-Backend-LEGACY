using FluentValidation;

namespace FuDever.Application.Features.Department.CreateDepartment;

/// <summary>
///     Create department request validator.
/// </summary>
public sealed class CreateDepartmentRequestValidator : AbstractValidator<CreateDepartmentRequest>
{
    public CreateDepartmentRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.NewDepartmentName)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty()
            .MaximumLength(maximumLength: Domain.Entities.Department.Metadata.Name.MaxLength)
            .MinimumLength(minimumLength: Domain.Entities.Department.Metadata.Name.MinLength);
    }
}
