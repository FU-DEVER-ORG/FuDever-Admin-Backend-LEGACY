using FuDever.Application.Features.Auth.RequestForgotPassword.Middlewares;
using MediatR;

namespace FuDever.Application.Features.Auth.RequestForgotPassword;

/// <summary>
///      Request Forgot Password request.
/// </summary>
public sealed class RequestForgotPasswordRequest
    : IRequest<RequestForgotPasswordResponse>,
        IRequestForgotPasswordMiddleware
{
    public string Username { get; init; }
}
