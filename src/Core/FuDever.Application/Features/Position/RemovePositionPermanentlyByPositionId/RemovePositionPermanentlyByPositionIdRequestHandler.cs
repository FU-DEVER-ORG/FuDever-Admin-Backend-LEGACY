using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Position.RemovePositionPermanentlyByPositionId;

/// <summary>
///     Remove position permanently by position id request handler.
/// </summary>
internal sealed class RemovePositionPermanentlyByPositionIdRequestHandler
    : IRequestHandler<
        RemovePositionPermanentlyByPositionIdRequest,
        RemovePositionPermanentlyByPositionIdResponse
    >
{
    private readonly IUnitOfWork _unitOfWork;

    public RemovePositionPermanentlyByPositionIdRequestHandler(IUnitOfWork unitOfWork)
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
    public async Task<RemovePositionPermanentlyByPositionIdResponse> Handle(
        RemovePositionPermanentlyByPositionIdRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is position found by position id.
        var isPositionFound =
            await _unitOfWork.PositionFeature.RemovePositionPermanentlyByPositionId.Query.IsPositionFoundByPositionIdQueryAsync(
                positionId: request.PositionId,
                cancellationToken: cancellationToken
            );

        // Position is not found by position id.
        if (!isPositionFound)
        {
            return new()
            {
                StatusCode =
                    RemovePositionPermanentlyByPositionIdResponseStatusCode.POSITION_IS_NOT_FOUND
            };
        }

        // Is position temporarily removed by position id.
        var isPositionTemporarilyRemoved =
            await _unitOfWork.PositionFeature.RemovePositionPermanentlyByPositionId.Query.IsPositionTemporarilyRemovedByPositionIdQueryAsync(
                positionId: request.PositionId,
                cancellationToken: cancellationToken
            );

        // Position is not temporarily removed by position id.
        if (!isPositionTemporarilyRemoved)
        {
            return new()
            {
                StatusCode =
                    RemovePositionPermanentlyByPositionIdResponseStatusCode.POSITION_IS_NOT_TEMPORARILY_REMOVED
            };
        }

        // Remove position permanently by position id.
        var result =
            await _unitOfWork.PositionFeature.RemovePositionPermanentlyByPositionId.Command.RemovePositionPermanentlyByPositionIdCommandAsync(
                positionId: request.PositionId,
                cancellationToken: cancellationToken
            );

        // Database transaction false.
        if (!result)
        {
            return new()
            {
                StatusCode =
                    RemovePositionPermanentlyByPositionIdResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        return new()
        {
            StatusCode = RemovePositionPermanentlyByPositionIdResponseStatusCode.OPERATION_SUCCESS
        };
    }
}
