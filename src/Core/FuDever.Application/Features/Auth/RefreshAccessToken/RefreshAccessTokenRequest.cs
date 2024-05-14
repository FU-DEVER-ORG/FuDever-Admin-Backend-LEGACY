using FuDever.Application.Features.Auth.RefreshAccessToken.Middlewares;
using MediatR;

namespace FuDever.Application.Features.Auth.RefreshAccessToken;

/// <summary>
///     Refresh access token request.
/// </summary>
public sealed class RefreshAccessTokenRequest
    : IRequest<RefreshAccessTokenResponse>,
        IRefreshAccessTokenMiddleware
{
    public string RefreshToken { get; init; }
}
