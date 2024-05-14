using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.JsonWebTokens;

namespace FuDever.Application.Features.Position.RemovePositionTemporarilyByPositionId;

/// <summary>
///     Remove position temporarily by position id request handler.
/// </summary>
internal sealed class RemovePositionTemporarilyByPositionIdRequestHandler
    : IRequestHandler<
        RemovePositionTemporarilyByPositionIdRequest,
        RemovePositionTemporarilyByPositionIdResponse
    >
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public RemovePositionTemporarilyByPositionIdRequestHandler(
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor
    )
    {
        _unitOfWork = unitOfWork;
        _httpContextAccessor = httpContextAccessor;
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
    public async Task<RemovePositionTemporarilyByPositionIdResponse> Handle(
        RemovePositionTemporarilyByPositionIdRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is position found by position id.
        var isPositionFound =
            await _unitOfWork.PositionFeature.removePositionTemporarilyByPositionId.Query.IsPositionFoundByPositionIdQueryAsync(
                positionId: request.PositionId,
                cancellationToken: cancellationToken
            );

        // Position is not found by position id.
        if (!isPositionFound)
        {
            return new()
            {
                StatusCode =
                    RemovePositionTemporarilyByPositionIdResponseStatusCode.POSITION_IS_NOT_FOUND
            };
        }

        // Is position temporarily removed by position id.
        var isPositionTemporarilyRemoved =
            await _unitOfWork.PositionFeature.removePositionTemporarilyByPositionId.Query.IsPositionTemporarilyRemovedByPositionIdQueryAsync(
                positionId: request.PositionId,
                cancellationToken: cancellationToken
            );

        // Position is already temporarily removed by position id.
        if (isPositionTemporarilyRemoved)
        {
            return new()
            {
                StatusCode =
                    RemovePositionTemporarilyByPositionIdResponseStatusCode.POSITION_IS_ALREADY_TEMPORARILY_REMOVED
            };
        }

        // Remove position temporarily by position id.
        var result =
            await _unitOfWork.PositionFeature.removePositionTemporarilyByPositionId.Command.RemovePositionTemporarilyByPositionIdCommandAsync(
                positionId: request.PositionId,
                removedAt: DateTime.UtcNow,
                removedBy: Guid.Parse(
                    input: _httpContextAccessor.HttpContext.User.FindFirstValue(
                        claimType: JwtRegisteredClaimNames.Sub
                    )
                ),
                cancellationToken: cancellationToken
            );

        // Database transaction false.
        if (!result)
        {
            return new()
            {
                StatusCode =
                    RemovePositionTemporarilyByPositionIdResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        return new()
        {
            StatusCode = RemovePositionTemporarilyByPositionIdResponseStatusCode.OPERATION_SUCCESS
        };
    }
}
