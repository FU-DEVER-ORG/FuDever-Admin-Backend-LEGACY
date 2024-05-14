using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Features.Platform.GetAllPlatforms;
using FuDever.Application.Features.Platform.GetAllPlatformsByPlatformName;
using FuDever.Application.Features.Platform.GetAllTemporarilyRemovedPlatforms;
using FuDever.Application.Shared.Attributes;
using FuDever.Application.Shared.Caching;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Platform.RestorePlatformByPlatformId.Middlewares;

/// <summary>
///     Restore platform by platform
///     id request caching middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 3)]
internal sealed class RestorePlatformByPlatformIdCachingMiddleware
    : IPipelineBehavior<RestorePlatformByPlatformIdRequest, RestorePlatformByPlatformIdResponse>,
        IRestorePlatformByPlatformIdMiddleware
{
    private readonly ICacheHandler _cacheHandler;
    private readonly IUnitOfWork _unitOfWork;

    public RestorePlatformByPlatformIdCachingMiddleware(
        ICacheHandler cacheHandler,
        IUnitOfWork unitOfWork
    )
    {
        _cacheHandler = cacheHandler;
        _unitOfWork = unitOfWork;
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
    public async Task<RestorePlatformByPlatformIdResponse> Handle(
        RestorePlatformByPlatformIdRequest request,
        RequestHandlerDelegate<RestorePlatformByPlatformIdResponse> next,
        CancellationToken cancellationToken
    )
    {
        var response = await next();

        if (response.StatusCode == RestorePlatformByPlatformIdResponseStatusCode.OPERATION_SUCCESS)
        {
            var foundPlatform =
                await _unitOfWork.PlatformFeature.RestorePlatformByPlatformId.Query.FindPlatformByPlatformIdForCacheClearing(
                    platformId: request.PlatformId,
                    cancellationToken: cancellationToken
                );

            await Task.WhenAll(
                _cacheHandler.RemoveAsync(
                    key: $"{nameof(GetAllPlatformsByPlatformNameRequest)}_param_{foundPlatform.Name.ToLower()}",
                    cancellationToken: cancellationToken
                ),
                _cacheHandler.RemoveAsync(
                    key: nameof(GetAllPlatformsRequest),
                    cancellationToken: cancellationToken
                ),
                _cacheHandler.RemoveAsync(
                    key: nameof(GetAllTemporarilyRemovedPlatformsRequest),
                    cancellationToken: cancellationToken
                )
            );
        }

        return response;
    }
}
