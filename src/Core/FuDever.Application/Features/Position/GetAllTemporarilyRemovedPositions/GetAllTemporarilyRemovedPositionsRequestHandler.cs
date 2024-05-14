using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Position.GetAllTemporarilyRemovedPositions;

/// <summary>
///     Get all temporarily removed positions request handler.
/// </summary>
internal sealed class GetAllTemporarilyRemovedPositionsRequestHandler
    : IRequestHandler<
        GetAllTemporarilyRemovedPositionsRequest,
        GetAllTemporarilyRemovedPositionsResponse
    >
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTemporarilyRemovedPositionsRequestHandler(IUnitOfWork unitOfWork)
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
    ///     A task containing the boolean result.
    /// </returns>
    public async Task<GetAllTemporarilyRemovedPositionsResponse> Handle(
        GetAllTemporarilyRemovedPositionsRequest request,
        CancellationToken cancellationToken
    )
    {
        // Get all temporarily removed positions.
        var foundTemporarilyRemovedPositions =
            await _unitOfWork.PositionFeature.GetAllTemporarilyRemovedPositions.Query.GetAllTemporarilyRemovedPositionsQueryAsync(
                cancellationToken: cancellationToken
            );

        // Project result to response.
        return new()
        {
            StatusCode = GetAllTemporarilyRemovedPositionsResponseStatusCode.OPERATION_SUCCESS,
            FoundTemporarilyRemovedPositions = foundTemporarilyRemovedPositions.Select(
                selector: foundPosition =>
                {
                    return new GetAllTemporarilyRemovedPositionsResponse.Position()
                    {
                        PositionId = foundPosition.Id,
                        PositionName = foundPosition.Name,
                        PositionRemovedAt = foundPosition.RemovedAt,
                        PositionRemovedBy = foundPosition.RemovedBy
                    };
                }
            )
        };
    }
}
