using FluentValidation;

namespace FuDever.Application.Features.Auth.Login;

/// <summary>
///     Login request validator.
/// </summary>
public sealed class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
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
