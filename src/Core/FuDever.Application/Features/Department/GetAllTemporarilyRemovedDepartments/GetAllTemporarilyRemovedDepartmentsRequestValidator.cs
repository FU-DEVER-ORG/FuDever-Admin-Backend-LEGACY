using FluentValidation;

namespace FuDever.Application.Features.Department.GetAllTemporarilyRemovedDepartments;

/// <summary>
///     Get all temporarily removed departments request validator.
/// </summary>
public sealed class GetAllTemporarilyRemovedDepartmentsRequestValidator
    : AbstractValidator<GetAllTemporarilyRemovedDepartmentsRequest>
{
    public GetAllTemporarilyRemovedDepartmentsRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.CacheExpiredTime)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .Must(predicate: cacheExpiredTime => cacheExpiredTime >= default(int));
    }
}
