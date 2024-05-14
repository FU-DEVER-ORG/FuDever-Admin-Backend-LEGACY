using FluentValidation;

namespace FuDever.Application.Features.Role.GetAllRolesByRoleName;

/// <summary>
///     Get all roles by role name request validator.
/// </summary>
public sealed class GetAllRolesByRoleNameRequestValidator
    : AbstractValidator<GetAllRolesByRoleNameRequest>
{
    public GetAllRolesByRoleNameRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.RoleName)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty()
            .MaximumLength(maximumLength: Domain.Entities.Role.Metadata.Name.MaxLength)
            .MinimumLength(minimumLength: Domain.Entities.Role.Metadata.Name.MinLength);

        RuleFor(expression: request => request.CacheExpiredTime)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .Must(predicate: cacheExpiredTime => cacheExpiredTime >= default(int));
    }
}
