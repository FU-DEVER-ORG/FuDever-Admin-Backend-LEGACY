using FluentValidation;

namespace FuDever.Application.Features.Auth.ResendUserRegistrationConfirmedEmail;

/// <summary>
///     Validator for resending user registration confirmed email request.
/// </summary>
public sealed class ResendUserRegistrationConfirmedEmailRequestValidator
    : AbstractValidator<ResendUserRegistrationConfirmedEmailRequest>
{
    public ResendUserRegistrationConfirmedEmailRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.Username)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(maximumLength: Domain.Entities.User.Metadata.UserName.MaxLength)
            .MinimumLength(minimumLength: Domain.Entities.User.Metadata.UserName.MinLength);

        RuleFor(expression: request => request.CacheExpiredTime)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .Must(predicate: cacheExpiredTime => cacheExpiredTime >= default(int));
    }
}
