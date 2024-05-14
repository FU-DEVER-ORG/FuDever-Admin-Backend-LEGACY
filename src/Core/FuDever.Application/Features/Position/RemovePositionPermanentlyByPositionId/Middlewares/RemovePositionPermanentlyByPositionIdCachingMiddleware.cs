using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Features.Position.GetAllTemporarilyRemovedPositions;
using FuDever.Application.Shared.Attributes;
using FuDever.Application.Shared.Caching;
using MediatR;

namespace FuDever.Application.Features.Position.RemovePositionPermanentlyByPositionId.Middlewares;

/// <summary>
///     Remove permanently position by
///     position id request caching middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 3)]
internal sealed class RemovePositionPermanentlyByPositionIdCachingMiddleware
    : IPipelineBehavior<
        RemovePositionPermanentlyByPositionIdRequest,
        RemovePositionPermanentlyByPositionIdResponse
    >,
        IRemovePositionPermanentlyByPositionIdMiddleware
{
    private readonly ICacheHandler _cacheHandler;

    public RemovePositionPermanentlyByPositionIdCachingMiddleware(ICacheHandler cacheHandler)
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
    public async Task<RemovePositionPermanentlyByPositionIdResponse> Handle(
        RemovePositionPermanentlyByPositionIdRequest request,
        RequestHandlerDelegate<RemovePositionPermanentlyByPositionIdResponse> next,
        CancellationToken cancellationToken
    )
    {
        var response = await next();

        if (
            response.StatusCode
            == RemovePositionPermanentlyByPositionIdResponseStatusCode.OPERATION_SUCCESS
        )
        {
            await _cacheHandler.RemoveAsync(
                key: nameof(GetAllTemporarilyRemovedPositionsRequest),
                cancellationToken: cancellationToken
            );
        }

        return response;
    }
}
