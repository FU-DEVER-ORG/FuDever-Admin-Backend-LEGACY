using FuDever.Application.Features.Auth.ChangingPassword.Middlewares;
using MediatR;

namespace FuDever.Application.Features.Auth.ChangingPassword;

/// <summary>
///     Changing Password request.
/// </summary>
public sealed class ChangingPasswordRequest
    : IRequest<ChangingPasswordResponse>,
        IChangingPasswordMiddleware
{
    public string NewPassword { get; init; }

    public string ResetPasswordToken { get; init; }
}
