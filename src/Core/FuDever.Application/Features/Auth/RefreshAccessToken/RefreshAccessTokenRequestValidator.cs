using FluentValidation;

namespace FuDever.Application.Features.Auth.RefreshAccessToken;

/// <summary>
///     Refresh access token request validator.
/// </summary>
public sealed class RefreshAccessTokenRequestValidator
    : AbstractValidator<RefreshAccessTokenRequest>
{
    public RefreshAccessTokenRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.RefreshToken)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty();
    }
}
