using FluentValidation;

namespace FuDever.Application.Features.Auth.ChangingPassword;

/// <summary>
///     Changing Password request validator.
/// </summary>
public sealed class ChangingPasswordRequestValidator : AbstractValidator<ChangingPasswordRequest>
{
    public ChangingPasswordRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.NewPassword)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty()
            .MaximumLength(maximumLength: Domain.Entities.User.Metadata.Password.MaxLength)
            .MinimumLength(minimumLength: Domain.Entities.User.Metadata.Password.MinLength);

        RuleFor(expression: request => request.ResetPasswordToken)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty();
    }
}
