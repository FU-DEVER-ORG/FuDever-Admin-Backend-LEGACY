using FluentValidation;

namespace FuDever.Application.Features.Department.RemoveDepartmentPermanentlyByDepartmentId;

/// <summary>
///     Remove department permanently by department id request validator.
/// </summary>
public sealed class RemoveDepartmentPermanentlyByDepartmentIdRequestValidator
    : AbstractValidator<RemoveDepartmentPermanentlyByDepartmentIdRequest>
{
    public RemoveDepartmentPermanentlyByDepartmentIdRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.DepartmentId)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty();
    }
}
