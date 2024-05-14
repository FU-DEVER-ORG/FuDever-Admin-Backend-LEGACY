using FluentValidation;

namespace FuDever.Application.Features.Auth.ConfirmUserRegistrationConfirmedEmail;

/// <summary>
///     Validator for confirm user registration confirmed email request.
/// </summary>
public sealed class ConfirmUserRegistrationConfirmedEmailRequestValidator
    : AbstractValidator<ConfirmUserRegistrationConfirmedEmailRequest>
{
    public ConfirmUserRegistrationConfirmedEmailRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.UserRegistrationEmailConfirmedTokenAsBase64)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty();

        RuleFor(expression: request => request.CacheExpiredTime)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .Must(predicate: cacheExpiredTime => cacheExpiredTime >= default(int));
    }
}
