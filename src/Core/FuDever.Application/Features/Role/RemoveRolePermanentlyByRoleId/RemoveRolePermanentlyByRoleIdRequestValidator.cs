using FluentValidation;

namespace FuDever.Application.Features.Role.RemoveRolePermanentlyByRoleId;

/// <summary>
///     Remove role permanently by role id request validator.
/// </summary>
public sealed class RemoveRolePermanentlyByRoleIdRequestValidator
    : AbstractValidator<RemoveRolePermanentlyByRoleIdRequest>
{
    public RemoveRolePermanentlyByRoleIdRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.RoleId)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty();
    }
}
