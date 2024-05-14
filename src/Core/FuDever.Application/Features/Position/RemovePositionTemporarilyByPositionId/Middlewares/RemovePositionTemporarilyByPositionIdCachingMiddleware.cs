using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Features.Position.GetAllPositions;
using FuDever.Application.Features.Position.GetAllPositionsByPositionName;
using FuDever.Application.Features.Position.GetAllTemporarilyRemovedPositions;
using FuDever.Application.Shared.Attributes;
using FuDever.Application.Shared.Caching;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Position.RemovePositionTemporarilyByPositionId.Middlewares;

/// <summary>
///     Remove position temporarily by position
///     id request caching middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 3)]
internal sealed class RemovePositionTemporarilyByPositionIdCachingMiddleware
    : IPipelineBehavior<
        RemovePositionTemporarilyByPositionIdRequest,
        RemovePositionTemporarilyByPositionIdResponse
    >,
        IRemovePositionTemporarilyByPositionIdMiddleware
{
    private readonly ICacheHandler _cacheHandler;
    private readonly IUnitOfWork _unitOfWork;

    public RemovePositionTemporarilyByPositionIdCachingMiddleware(
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
    public async Task<RemovePositionTemporarilyByPositionIdResponse> Handle(
        RemovePositionTemporarilyByPositionIdRequest request,
        RequestHandlerDelegate<RemovePositionTemporarilyByPositionIdResponse> next,
        CancellationToken cancellationToken
    )
    {
        var response = await next();

        if (
            response.StatusCode
            == RemovePositionTemporarilyByPositionIdResponseStatusCode.OPERATION_SUCCESS
        )
        {
            var foundPosition =
                await _unitOfWork.PositionFeature.removePositionTemporarilyByPositionId.Query.FindPositionByPositionIdForCacheClearing(
                    positionId: request.PositionId,
                    cancellationToken: cancellationToken
                );

            await Task.WhenAll(
                _cacheHandler.RemoveAsync(
                    key: $"{nameof(GetAllPositionsByPositionNameRequest)}_param_{foundPosition.Name.ToLower()}",
                    cancellationToken: cancellationToken
                ),
                _cacheHandler.RemoveAsync(
                    key: nameof(GetAllPositionsRequest),
                    cancellationToken: cancellationToken
                ),
                _cacheHandler.RemoveAsync(
                    key: nameof(GetAllTemporarilyRemovedPositionsRequest),
                    cancellationToken: cancellationToken
                )
            );
        }

        return response;
    }
}
