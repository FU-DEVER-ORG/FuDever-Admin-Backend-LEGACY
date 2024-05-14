using FluentValidation;

namespace FuDever.Application.Features.Role.CreateRole;

/// <summary>
///     Create role request validator.
/// </summary>
public sealed class CreateRoleRequestValidator : AbstractValidator<CreateRoleRequest>
{
    public CreateRoleRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.NewRoleName)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty()
            .MaximumLength(maximumLength: Domain.Entities.Role.Metadata.Name.MaxLength)
            .MinimumLength(minimumLength: Domain.Entities.Role.Metadata.Name.MinLength);
    }
}
