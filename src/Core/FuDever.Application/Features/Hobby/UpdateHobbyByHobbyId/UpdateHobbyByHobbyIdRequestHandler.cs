using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Hobby.UpdateHobbyByHobbyId;

/// <summary>
///     Update hobby by hobby id request handler.
/// </summary>
internal sealed class UpdateHobbyByHobbyIdRequestHandler
    : IRequestHandler<UpdateHobbyByHobbyIdRequest, UpdateHobbyByHobbyIdResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateHobbyByHobbyIdRequestHandler(IUnitOfWork unitOfWork)
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
    public async Task<UpdateHobbyByHobbyIdResponse> Handle(
        UpdateHobbyByHobbyIdRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is hobby found by hobby id.
        var isHobbyFoundByHobbyId =
            await _unitOfWork.HobbyFeature.UpdateHobbyByHobbyId.Query.IsHobbyFoundByHobbyIdQueryAsync(
                hobbyId: request.HobbyId,
                cancellationToken: cancellationToken
            );

        // Hobby is not found by hobby id.
        if (!isHobbyFoundByHobbyId)
        {
            return new() { StatusCode = UpdateHobbyByHobbyIdResponseStatusCode.HOBBY_IS_NOT_FOUND };
        }

        // Is hobby temporarily removed by hobby id.
        var isHobbyTemporarilyRemoved =
            await _unitOfWork.HobbyFeature.UpdateHobbyByHobbyId.Query.IsHobbyTemporarilyRemovedByHobbyIdQueryAsync(
                hobbyId: request.HobbyId,
                cancellationToken: cancellationToken
            );

        // Hobby is already temporarily removed by hobby id.
        if (isHobbyTemporarilyRemoved)
        {
            return new()
            {
                StatusCode =
                    UpdateHobbyByHobbyIdResponseStatusCode.HOBBY_IS_ALREADY_TEMPORARILY_REMOVED
            };
        }

        // Is hobby with the same hobby name found.
        var isHobbyWithTheSameNameFound =
            await _unitOfWork.HobbyFeature.UpdateHobbyByHobbyId.Query.IsHobbyWithTheSameNameFoundByHobbyNameQueryAsync(
                newHobbyName: request.NewHobbyName,
                cancellationToken: cancellationToken
            );

        // Hobby with the same hobby name is found.
        if (isHobbyWithTheSameNameFound)
        {
            return new()
            {
                StatusCode = UpdateHobbyByHobbyIdResponseStatusCode.HOBBY_ALREADY_EXISTS
            };
        }

        // Update hobby by hobby id.
        var result =
            await _unitOfWork.HobbyFeature.UpdateHobbyByHobbyId.Command.UpdateHobbyByHobbyIdCommandAsync(
                hobbyId: request.HobbyId,
                newHobbyName: request.NewHobbyName,
                cancellationToken: cancellationToken
            );

        // Database transaction false.
        if (!result)
        {
            return new()
            {
                StatusCode = UpdateHobbyByHobbyIdResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        return new() { StatusCode = UpdateHobbyByHobbyIdResponseStatusCode.OPERATION_SUCCESS };
    }
}
