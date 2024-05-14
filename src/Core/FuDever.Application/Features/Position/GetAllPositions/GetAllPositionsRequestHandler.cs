using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Position.GetAllPositions;

/// <summary>
///     Get all positions request handler.
/// </summary>
internal sealed class GetAllPositionsRequestHandler
    : IRequestHandler<GetAllPositionsRequest, GetAllPositionsResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPositionsRequestHandler(IUnitOfWork unitOfWork)
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
    public async Task<GetAllPositionsResponse> Handle(
        GetAllPositionsRequest request,
        CancellationToken cancellationToken
    )
    {
        // Get all non temporarily removed positions.
        var foundDepartments =
            await _unitOfWork.PositionFeature.GetAllPositions.Query.GetAllNonTemporarilyRemovedPositionsQueryAsync(
                cancellationToken: cancellationToken
            );

        // Project result to response.
        return new()
        {
            StatusCode = GetAllPositionsResponseStatusCode.OPERATION_SUCCESS,
            FoundPositions = foundDepartments.Select(selector: foundPosition =>
            {
                return new GetAllPositionsResponse.Position()
                {
                    PositionId = foundPosition.Id,
                    PositionName = foundPosition.Name
                };
            })
        };
    }
}
