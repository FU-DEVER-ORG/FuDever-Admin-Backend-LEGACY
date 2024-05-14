using FluentValidation;

namespace FuDever.Application.Features.Role.RestoreRoleByRoleId;

/// <summary>
///     Restore role by role id request validator.
/// </summary>
public sealed class RestoreRoleByRoleIdRequestValidator
    : AbstractValidator<RestoreRoleByRoleIdRequest>
{
    public RestoreRoleByRoleIdRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.RoleId)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty();
    }
}
