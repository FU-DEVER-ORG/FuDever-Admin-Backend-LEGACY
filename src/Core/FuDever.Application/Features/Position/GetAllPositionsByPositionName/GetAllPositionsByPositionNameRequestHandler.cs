using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Position.GetAllPositionsByPositionName;

/// <summary>
///     Get all position by position name request handler.
/// </summary>
internal sealed class GetAllPositionsByPositionNameRequestHandler
    : IRequestHandler<GetAllPositionsByPositionNameRequest, GetAllPositionsByPositionNameResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPositionsByPositionNameRequestHandler(IUnitOfWork unitOfWork)
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

    public async Task<GetAllPositionsByPositionNameResponse> Handle(
        GetAllPositionsByPositionNameRequest request,
        CancellationToken cancellationToken
    )
    {
        // Get all positions by name.
        var foundPositions =
            await _unitOfWork.PositionFeature.GetAllPositionsByPositionName.Query.GetAllPositionsByPositionNameQueryAsync(
                positionName: request.PositionName,
                cancellationToken: cancellationToken
            );

        return new()
        {
            StatusCode = GetAllPositionsByPositionNameResponseStatusCode.OPERATION_SUCCESS,
            FoundPositions = foundPositions.Select(selector: foundPosition =>
            {
                return new GetAllPositionsByPositionNameResponse.Position()
                {
                    PositionId = foundPosition.Id,
                    PositionName = foundPosition.Name
                };
            }),
        };
    }
}
