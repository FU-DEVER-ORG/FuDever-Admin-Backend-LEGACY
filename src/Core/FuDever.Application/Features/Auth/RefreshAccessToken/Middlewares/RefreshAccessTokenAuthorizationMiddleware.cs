using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Shared.Attributes;
using FuDever.Application.Shared.Authorization;
using MediatR;

namespace FuDever.Application.Features.Auth.RefreshAccessToken.Middlewares;

/// <summary>
///     Refresh access token request authorization middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 1)]
internal sealed class RefreshAccessTokenAuthorizationMiddleware
    : IPipelineBehavior<RefreshAccessTokenRequest, RefreshAccessTokenResponse>,
        IRefreshAccessTokenMiddleware
{
    private readonly ISender _sender;

    public RefreshAccessTokenAuthorizationMiddleware(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    ///     Entry to middleware handler.
    /// </summary>
    /// <param name="request">
    ///     Current request object.
    /// </param>
    /// <param name="next">
    ///     Navigate to next middleware and get back response.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used for notifying system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     Response of use case.
    /// </returns>
    public async Task<RefreshAccessTokenResponse> Handle(
        RefreshAccessTokenRequest request,
        RequestHandlerDelegate<RefreshAccessTokenResponse> next,
        CancellationToken cancellationToken
    )
    {
        IEnumerable<IAppAuthorizationRequirement> requirements =
        [
            new Authorizations.ValidateAccessToken.ValidateAccessTokenRequirement()
        ];

        foreach (var requirement in requirements)
        {
            var result = await _sender.Send(
                request: requirement,
                cancellationToken: cancellationToken
            );

            if (!result.IsAuthorized)
            {
                return new() { StatusCode = RefreshAccessTokenResponseStatusCode.UN_AUTHORIZED };
            }

            if (!result.IsForbidden)
            {
                return new() { StatusCode = RefreshAccessTokenResponseStatusCode.FORBIDDEN };
            }
        }

        return await next();
    }
}
