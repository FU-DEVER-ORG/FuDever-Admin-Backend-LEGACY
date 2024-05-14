using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Position.UpdatePositionByPositionId;

/// <summary>
///     Update position by position id request handler.
/// </summary>
internal sealed class UpdatePositionByPositionIdRequestHandler
    : IRequestHandler<UpdatePositionByPositionIdRequest, UpdatePositionByPositionIdResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePositionByPositionIdRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
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

    public async Task<UpdatePositionByPositionIdResponse> Handle(
        UpdatePositionByPositionIdRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is position found by position id.
        var isPositionFoundByPositionId =
            await _unitOfWork.PositionFeature.UpdatePositionByPositionId.Query.IsPositionFoundByPositionIdQueryAsync(
                positionId: request.PositionId,
                cancellationToken: cancellationToken
            );

        // position is not found by position id.
        if (!isPositionFoundByPositionId)
        {
            return new()
            {
                StatusCode = UpdatePositionByPositionIdResponseStatusCode.POSITION_IS_NOT_FOUND
            };
        }

        // Is position temporarily removed by position id.
        var isPositionTemporarilyRemoved =
            await _unitOfWork.PositionFeature.UpdatePositionByPositionId.Query.IsPositionTemporarilyRemovedByPositionIdQueryAsync(
                positionId: request.PositionId,
                cancellationToken: cancellationToken
            );

        // Position is already temporarily removed by position id.
        if (isPositionTemporarilyRemoved)
        {
            return new()
            {
                StatusCode =
                    UpdatePositionByPositionIdResponseStatusCode.POSITION_IS_ALREADY_TEMPORARILY_REMOVED
            };
        }

        // Is position with the same position name found.
        var isPositionWithTheSameNameFound =
            await _unitOfWork.PositionFeature.UpdatePositionByPositionId.Query.IsPositionWithTheSameNameFoundByPositionNameQueryAsync(
                newPositionName: request.NewPositionName,
                cancellationToken: cancellationToken
            );

        // Position with the same position name is found.
        if (isPositionWithTheSameNameFound)
        {
            return new()
            {
                StatusCode = UpdatePositionByPositionIdResponseStatusCode.POSITION_ALREADY_EXISTS
            };
        }

        // Update position by position id.
        var result =
            await _unitOfWork.PositionFeature.UpdatePositionByPositionId.Command.UpdatePositionByPositionIdCommandAsync(
                positionId: request.PositionId,
                newPositionName: request.NewPositionName,
                cancellationToken: cancellationToken
            );

        // Database transaction false.
        if (!result)
        {
            return new()
            {
                StatusCode = UpdatePositionByPositionIdResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        return new()
        {
            StatusCode = UpdatePositionByPositionIdResponseStatusCode.OPERATION_SUCCESS
        };
    }
}
