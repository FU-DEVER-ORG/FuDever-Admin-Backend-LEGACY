using FluentValidation;

namespace FuDever.Application.Features.Auth.RequestForgotPassword;

/// <summary>
///     Request Forgot Password request validation.
/// </summary>
public sealed class RequestForgotPasswordRequestValidation
    : AbstractValidator<RequestForgotPasswordRequest>
{
    public RequestForgotPasswordRequestValidation()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(expression: request => request.Username)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(maximumLength: Domain.Entities.User.Metadata.UserName.MaxLength)
            .MinimumLength(minimumLength: Domain.Entities.User.Metadata.UserName.MinLength);
    }
}
