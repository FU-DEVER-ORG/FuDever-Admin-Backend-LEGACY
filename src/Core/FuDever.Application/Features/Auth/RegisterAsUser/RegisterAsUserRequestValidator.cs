using FluentValidation;

namespace FuDever.Application.Features.Auth.RegisterAsUser;

/// <summary>
///     Register as user request validator.
/// </summary>
public sealed class RegisterAsUserRequestValidator : AbstractValidator<RegisterAsUserRequest>
{
    public RegisterAsUserRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.Username)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(maximumLength: Domain.Entities.User.Metadata.UserName.MaxLength)
            .MinimumLength(minimumLength: Domain.Entities.User.Metadata.UserName.MinLength);

        RuleFor(expression: request => request.Password)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty()
            .Matches(expression: @"^(?=.*\d)(?=.*[A-Z]).+$")
            .MaximumLength(maximumLength: Domain.Entities.User.Metadata.Password.MaxLength)
            .MinimumLength(minimumLength: Domain.Entities.User.Metadata.Password.MinLength);
    }
}
