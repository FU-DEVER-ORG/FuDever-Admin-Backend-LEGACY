using FluentValidation;

namespace FuDever.Application.Features.Role.UpdateRoleByRoleId;

/// <summary>
///     Update role by role id request validator.
/// </summary>
public sealed class UpdateRoleByRoleIdRequestValidator
    : AbstractValidator<UpdateRoleByRoleIdRequest>
{
    public UpdateRoleByRoleIdRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.RoleId)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty();

        RuleFor(expression: request => request.NewRoleName)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty()
            .MaximumLength(maximumLength: Domain.Entities.Role.Metadata.Name.MaxLength)
            .MinimumLength(minimumLength: Domain.Entities.Role.Metadata.Name.MinLength);
    }
}
