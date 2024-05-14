using FuDever.Application.Features.Auth.RegisterAsUser.Middlewares;
using MediatR;

namespace FuDever.Application.Features.Auth.RegisterAsUser;

/// <summary>
///     Request for register as user feature.
/// </summary>
public sealed class RegisterAsUserRequest
    : IRequest<RegisterAsUserResponse>,
        IRegisterAsUserMiddleware
{
    public string Username { get; init; }

    public string Password { get; init; }
}
