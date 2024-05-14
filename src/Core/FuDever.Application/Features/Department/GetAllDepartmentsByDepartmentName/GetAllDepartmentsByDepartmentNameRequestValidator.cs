using FluentValidation;

namespace FuDever.Application.Features.Department.GetAllDepartmentsByDepartmentName;

/// <summary>
///     Get all departments by department name request validator.
/// </summary>
public sealed class GetAllDepartmentsByDepartmentNameRequestValidator
    : AbstractValidator<GetAllDepartmentsByDepartmentNameRequest>
{
    public GetAllDepartmentsByDepartmentNameRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.DepartmentName)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty()
            .MaximumLength(maximumLength: Domain.Entities.Department.Metadata.Name.MaxLength)
            .MinimumLength(minimumLength: Domain.Entities.Department.Metadata.Name.MinLength);

        RuleFor(expression: request => request.CacheExpiredTime)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .Must(predicate: cacheExpiredTime => cacheExpiredTime >= default(int));
    }
}
