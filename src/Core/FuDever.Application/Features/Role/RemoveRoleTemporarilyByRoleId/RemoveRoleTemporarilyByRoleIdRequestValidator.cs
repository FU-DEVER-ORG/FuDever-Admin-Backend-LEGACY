using FluentValidation;

namespace FuDever.Application.Features.Role.RemoveRoleTemporarilyByRoleId;

/// <summary>
///     Remove role temporarily by role id request validator.
/// </summary>
public sealed class RemoveRoleTemporarilyByRoleIdRequestValidator
    : AbstractValidator<RemoveRoleTemporarilyByRoleIdRequest>
{
    public RemoveRoleTemporarilyByRoleIdRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.RoleId)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty();
    }
}
