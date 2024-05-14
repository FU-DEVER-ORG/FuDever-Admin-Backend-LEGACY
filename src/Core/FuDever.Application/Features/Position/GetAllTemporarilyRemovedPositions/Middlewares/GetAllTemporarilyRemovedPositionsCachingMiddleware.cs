using System;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Shared.Attributes;
using FuDever.Application.Shared.Caching;
using MediatR;

namespace FuDever.Application.Features.Position.GetAllTemporarilyRemovedPositions.Middlewares;

/// <summary>
///     Get all temporarily removed positions
///     request caching middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 3)]
internal sealed class GetAllTemporarilyRemovedPositionsCachingMiddleware
    : IPipelineBehavior<
        GetAllTemporarilyRemovedPositionsRequest,
        GetAllTemporarilyRemovedPositionsResponse
    >,
        IGetAllTemporarilyRemovedPositionsMiddleware
{
    private readonly ICacheHandler _cacheHandler;

    public GetAllTemporarilyRemovedPositionsCachingMiddleware(ICacheHandler cacheHandler)
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

    public async Task<GetAllTemporarilyRemovedPositionsResponse> Handle(
        GetAllTemporarilyRemovedPositionsRequest request,
        RequestHandlerDelegate<GetAllTemporarilyRemovedPositionsResponse> next,
        CancellationToken cancellationToken
    )
    {
        // Cache is not enable.
        if (request.CacheExpiredTime == default)
        {
            return await next();
        }

        const string cachedKey = nameof(GetAllTemporarilyRemovedPositionsRequest);

        // Retrieve from cache.
        var cacheModel = await _cacheHandler.GetAsync<GetAllTemporarilyRemovedPositionsResponse>(
            key: cachedKey,
            cancellationToken: cancellationToken
        );

        // Cache value does not exist.
        if (
            !Equals(
                objA: cacheModel,
                objB: AppCacheModel<GetAllTemporarilyRemovedPositionsResponse>.NotFound
            )
        )
        {
            return cacheModel.Value;
        }

        var response = await next();

        // Caching the return value.
        await _cacheHandler.SetAsync(
            key: cachedKey,
            value: response,
            new()
            {
                AbsoluteExpiration = DateTimeOffset.UtcNow.AddSeconds(
                    seconds: request.CacheExpiredTime
                )
            },
            cancellationToken: cancellationToken
        );

        return response;
    }
}
