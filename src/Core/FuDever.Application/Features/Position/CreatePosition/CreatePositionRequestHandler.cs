using System;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Shared.Data;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Position.CreatePosition;

/// <summary>
///     Create position request handler.
/// </summary>
internal sealed class CreatePositionRequestHandler
    : IRequestHandler<CreatePositionRequest, CreatePositionResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDbMinTimeHandler _dbMinTimeHandler;

    public CreatePositionRequestHandler(IUnitOfWork unitOfWork, IDbMinTimeHandler dbMinTimeHandler)
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
    public async Task<CreatePositionResponse> Handle(
        CreatePositionRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is position with the same position name found.
        var isPositionFound =
            await _unitOfWork.PositionFeature.CreatePosition.Query.IsPositionWithTheSameNameFoundByPositionNameQueryAsync(
                newPositionName: request.NewPositionName,
                cancellationToken: cancellationToken
            );

        // Positions with the same position name is found.
        if (isPositionFound)
        {
            // Is position temporarily removed by position name.
            var isPositionTemporarilyRemoved =
                await _unitOfWork.PositionFeature.CreatePosition.Query.IsPositionTemporarilyRemovedByPositionNameQueryAsync(
                    newPositionName: request.NewPositionName,
                    cancellationToken: cancellationToken
                );

            // Position with position name is already temporarily removed.
            if (isPositionTemporarilyRemoved)
            {
                return new()
                {
                    StatusCode =
                        CreatePositionResponseStatusCode.POSITION_IS_ALREADY_TEMPORARILY_REMOVED
                };
            }

            return new() { StatusCode = CreatePositionResponseStatusCode.POSITION_ALREADY_EXISTS };
        }

        // Create position with new position name.
        var result =
            await _unitOfWork.PositionFeature.CreatePosition.Command.CreatePositionCommandAsync(
                newPosition: InitNewPosition(newPositionName: request.NewPositionName),
                cancellationToken: cancellationToken
            );

        // Database transaction false.
        if (!result)
        {
            return new() { StatusCode = CreatePositionResponseStatusCode.DATABASE_OPERATION_FAIL };
        }

        return new() { StatusCode = CreatePositionResponseStatusCode.OPERATION_SUCCESS };
    }

    #region Others
    private Domain.Entities.Position InitNewPosition(string newPositionName)
    {
        return new()
        {
            Id = Guid.NewGuid(),
            Name = newPositionName,
            RemovedAt = _dbMinTimeHandler.Get(),
            RemovedBy = Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
        };
    }
    #endregion
}
