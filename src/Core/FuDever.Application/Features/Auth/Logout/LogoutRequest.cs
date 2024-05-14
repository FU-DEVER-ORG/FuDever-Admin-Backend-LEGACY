using FuDever.Application.Features.Auth.Logout.Middlewares;
using MediatR;

namespace FuDever.Application.Features.Auth.Logout;

/// <summary>
///     Logout request.
/// </summary>
public sealed class LogoutRequest : IRequest<LogoutResponse>, ILogoutMiddleware { }
