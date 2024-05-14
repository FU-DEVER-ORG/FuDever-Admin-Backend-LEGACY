using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Shared.Data;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Position.RestorePositionByPositionId;

/// <summary>
///     Restore position by position id request handler.
/// </summary>
internal sealed class RestorePositionByPositionIdRequestHandler
    : IRequestHandler<RestorePositionByPositionIdRequest, RestorePositionByPositionIdResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDbMinTimeHandler _dbMinTimeHandler;

    public RestorePositionByPositionIdRequestHandler(
        IUnitOfWork unitOfWork,
        IDbMinTimeHandler dbMinTimeHandler
    )
    {
        _unitOfWork = unitOfWork;
        _dbMinTimeHandler = dbMinTimeHandler;
    }

    /// <summary>
    ///     Entry of new request handler.
    /// </summary>
    /// <param name="request">
    ///     Request model.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used for notifying system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     A task containing the response.
    /// </returns>
    public async Task<RestorePositionByPositionIdResponse> Handle(
        RestorePositionByPositionIdRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is position found by position id.
        var isPositionFound =
            await _unitOfWork.PositionFeature.RestorePositionByPositionId.Query.IsPositionFoundByPositionIdQueryAsync(
                positionId: request.PositionId,
                cancellationToken: cancellationToken
            );

        // Position is not found by position id.
        if (!isPositionFound)
        {
            return new()
            {
                StatusCode = RestorePositionByPositionIdResponseStatusCode.POSITION_IS_NOT_FOUND
            };
        }

        // Is position temporarily removed by position id.
        var isPositionTemporarilyRemoved =
            await _unitOfWork.PositionFeature.RestorePositionByPositionId.Query.IsPositionTemporarilyRemovedByPositionIdQueryAsync(
                positionId: request.PositionId,
                cancellationToken: cancellationToken
            );

        // Position is not temporarily removed by position id.
        if (!isPositionTemporarilyRemoved)
        {
            return new()
            {
                StatusCode =
                    RestorePositionByPositionIdResponseStatusCode.POSITION_IS_NOT_TEMPORARILY_REMOVED
            };
        }

        // Restore position by position id.
        var result =
            await _unitOfWork.PositionFeature.RestorePositionByPositionId.Command.RestorePositionByPositionIdCommandAsync(
                positionId: request.PositionId,
                cancellationToken: cancellationToken
            );

        // Database transaction false.
        if (!result)
        {
            return new()
            {
                StatusCode = RestorePositionByPositionIdResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        return new()
        {
            StatusCode = RestorePositionByPositionIdResponseStatusCode.OPERATION_SUCCESS
        };
    }
}
