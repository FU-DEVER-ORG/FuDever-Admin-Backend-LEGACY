using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Features.Department.UpdateDepartmentByDepartmentId.Middlewares;
using FuDever.Application.Features.Position.GetAllPositions;
using FuDever.Application.Features.Position.GetAllPositionsByPositionName;
using FuDever.Application.Shared.Attributes;
using FuDever.Application.Shared.Caching;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Position.UpdatePositionByPositionId.Middlewares;

/// <summary>
///     Update position by position id
///     request caching middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 3)]
internal sealed class UpdatePositionByPositionIdCachingMiddleware
    : IPipelineBehavior<UpdatePositionByPositionIdRequest, UpdatePositionByPositionIdResponse>,
        IUpdateDepartmentByDepartmentIdMiddleware
{
    private readonly ICacheHandler _cacheHandler;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePositionByPositionIdCachingMiddleware(
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

    public async Task<UpdatePositionByPositionIdResponse> Handle(
        UpdatePositionByPositionIdRequest request,
        RequestHandlerDelegate<UpdatePositionByPositionIdResponse> next,
        CancellationToken cancellationToken
    )
    {
        // finding current position by position id.
        var foundPosition =
            await _unitOfWork.PositionFeature.UpdatePositionByPositionId.Query.FindPositionByPositionIdForCacheClearing(
                positionId: request.PositionId,
                cancellationToken: cancellationToken
            );

        // Position is found by position id.
        if (!Equals(objA: foundPosition, objB: default))
        {
            await _cacheHandler.RemoveAsync(
                key: $"{nameof(GetAllPositionsByPositionNameRequest)}_param_{foundPosition.Name.ToLower()}",
                cancellationToken: cancellationToken
            );
        }

        var response = await next();

        if (response.StatusCode == UpdatePositionByPositionIdResponseStatusCode.OPERATION_SUCCESS)
        {
            await Task.WhenAll(
                _cacheHandler.RemoveAsync(
                    key: $"{nameof(GetAllPositionsByPositionNameRequest)}_param_{request.NewPositionName.ToLower()}",
                    cancellationToken: cancellationToken
                ),
                _cacheHandler.RemoveAsync(
                    key: nameof(GetAllPositionsRequest),
                    cancellationToken: cancellationToken
                )
            );
        }

        return response;
    }
}
