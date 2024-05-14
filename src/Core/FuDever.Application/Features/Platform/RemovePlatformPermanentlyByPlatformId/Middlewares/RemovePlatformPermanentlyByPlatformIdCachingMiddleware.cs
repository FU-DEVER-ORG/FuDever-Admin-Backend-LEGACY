using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Features.Platform.GetAllTemporarilyRemovedPlatforms;
using FuDever.Application.Shared.Attributes;
using FuDever.Application.Shared.Caching;
using MediatR;

namespace FuDever.Application.Features.Platform.RemovePlatformPermanentlyByPlatformId.Middlewares;

/// <summary>
///     Remove platform permanently by platform id
///     request caching middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 3)]
internal sealed class RemovePlatformPermanentlyByPlatformIdCachingMiddleware
    : IPipelineBehavior<
        RemovePlatformPermanentlyByPlatformIdRequest,
        RemovePlatformPermanentlyByPlatformIdResponse
    >,
        IRemovePlatformPermanentlyByPlatformIdMiddleware
{
    private readonly ICacheHandler _cacheHandler;

    public RemovePlatformPermanentlyByPlatformIdCachingMiddleware(ICacheHandler cacheHandler)
    {
        _cacheHandler = cacheHandler;
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
    public async Task<RemovePlatformPermanentlyByPlatformIdResponse> Handle(
        RemovePlatformPermanentlyByPlatformIdRequest request,
        RequestHandlerDelegate<RemovePlatformPermanentlyByPlatformIdResponse> next,
        CancellationToken cancellationToken
    )
    {
        var response = await next();

        if (
            response.StatusCode
            == RemovePlatformPermanentlyByPlatformIdResponseStatusCode.OPERATION_SUCCESS
        )
        {
            await _cacheHandler.RemoveAsync(
                key: nameof(GetAllTemporarilyRemovedPlatformsRequest),
                cancellationToken: cancellationToken
            );
        }

        return response;
    }
}
