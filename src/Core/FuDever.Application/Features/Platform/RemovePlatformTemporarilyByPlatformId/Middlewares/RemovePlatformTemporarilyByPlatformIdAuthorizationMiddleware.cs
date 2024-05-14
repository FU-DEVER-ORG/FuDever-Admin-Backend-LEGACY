using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Shared.Attributes;
using FuDever.Application.Shared.Authorization;
using MediatR;

namespace FuDever.Application.Features.Platform.RemovePlatformTemporarilyByPlatformId.Middlewares;

/// <summary>
///     Remove platform temporarily by platform id
///     request authorization middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 1)]
internal sealed class RemovePlatformTemporarilyByPlatformIdAuthorizationMiddleware
    : IPipelineBehavior<
        RemovePlatformTemporarilyByPlatformIdRequest,
        RemovePlatformTemporarilyByPlatformIdResponse
    >,
        IRemovePlatformTemporarilyByPlatformIdMiddleware
{
    private readonly ISender _sender;

    public RemovePlatformTemporarilyByPlatformIdAuthorizationMiddleware(ISender sender)
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
    public async Task<RemovePlatformTemporarilyByPlatformIdResponse> Handle(
        RemovePlatformTemporarilyByPlatformIdRequest request,
        RequestHandlerDelegate<RemovePlatformTemporarilyByPlatformIdResponse> next,
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

            if (result.IsForbidden)
            {
                return new()
                {
                    StatusCode = RemovePlatformTemporarilyByPlatformIdResponseStatusCode.FORBIDDEN
                };
            }

            if (!result.IsAuthorized)
            {
                return new()
                {
                    StatusCode =
                        RemovePlatformTemporarilyByPlatformIdResponseStatusCode.UN_AUTHORIZED
                };
            }
        }

        return await next();
    }
}
