using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Shared.Data;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Hobby.RestoreHobbyByHobbyId;

/// <summary>
///     Restore hobby by hobby id request handler.
/// </summary>
internal sealed class RestoreHobbyByHobbyIdRequestHandler
    : IRequestHandler<RestoreHobbyByHobbyIdRequest, RestoreHobbyByHobbyIdResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDbMinTimeHandler _dbMinTimeHandler;

    public RestoreHobbyByHobbyIdRequestHandler(
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
    public async Task<RestoreHobbyByHobbyIdResponse> Handle(
        RestoreHobbyByHobbyIdRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is hobby found by hobby id.
        var isHobbyFoundByHobbyId =
            await _unitOfWork.HobbyFeature.RestoreHobbyByHobbyId.Query.IsHobbyFoundByHobbyIdQueryAsync(
                hobbyId: request.HobbyId,
                cancellationToken: cancellationToken
            );

        // Hobby is not found by hobby id.
        if (!isHobbyFoundByHobbyId)
        {
            return new()
            {
                StatusCode = RestoreHobbyByHobbyIdResponseStatusCode.HOBBY_IS_NOT_FOUND
            };
        }

        // Is hobby temporarily removed by hobby id.
        var isHobbyTemporarilyRemoved =
            await _unitOfWork.HobbyFeature.RestoreHobbyByHobbyId.Query.IsHobbyTemporarilyRemovedByHobbyIdQueryAsync(
                hobbyId: request.HobbyId,
                cancellationToken: cancellationToken
            );

        // Hobby is not temporarily removed by hobby id.
        if (!isHobbyTemporarilyRemoved)
        {
            return new()
            {
                StatusCode =
                    RestoreHobbyByHobbyIdResponseStatusCode.HOBBY_IS_NOT_TEMPORARILY_REMOVED
            };
        }

        // Restore hobby by hobby id.
        var result =
            await _unitOfWork.HobbyFeature.RestoreHobbyByHobbyId.Command.RestoreHobbyByHobbyIdCommandAsync(
                hobbyId: request.HobbyId,
                cancellationToken: cancellationToken
            );

        // Database transaction false.
        if (!result)
        {
            return new()
            {
                StatusCode = RestoreHobbyByHobbyIdResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        return new() { StatusCode = RestoreHobbyByHobbyIdResponseStatusCode.OPERATION_SUCCESS };
    }
}
