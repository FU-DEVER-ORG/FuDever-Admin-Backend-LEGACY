using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Hobby.RemoveHobbyPermanentlyByHobbyId;

/// <summary>
///     Remove hobby permanently by hobby id request handler.
/// </summary>
internal sealed class RemoveHobbyPermanentlyByHobbyIdRequestHandler
    : IRequestHandler<
        RemoveHobbyPermanentlyByHobbyIdRequest,
        RemoveHobbyPermanentlyByHobbyIdResponse
    >
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveHobbyPermanentlyByHobbyIdRequestHandler(IUnitOfWork unitOfWork)
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
    public async Task<RemoveHobbyPermanentlyByHobbyIdResponse> Handle(
        RemoveHobbyPermanentlyByHobbyIdRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is hobby found by hobby id.
        var isHobbyFoundByHobbyId =
            await _unitOfWork.HobbyFeature.RemoveHobbyPermanentlyByHobbyId.Query.IsHobbyFoundByHobbyIdQueryAsync(
                hobbyId: request.HobbyId,
                cancellationToken: cancellationToken
            );

        // Hobby is not found by hobby id.
        if (!isHobbyFoundByHobbyId)
        {
            return new()
            {
                StatusCode = RemoveHobbyPermanentlyByHobbyIdResponseStatusCode.HOBBY_IS_NOT_FOUND
            };
        }

        // Is hobby temporarily removed by hobby id.
        var isHobbyTemporarilyRemoved =
            await _unitOfWork.HobbyFeature.RemoveHobbyPermanentlyByHobbyId.Query.IsHobbyTemporarilyRemovedByHobbyIdQueryAsync(
                hobbyId: request.HobbyId,
                cancellationToken: cancellationToken
            );

        // Hobby is not temporarily removed by hobby id.
        if (!isHobbyTemporarilyRemoved)
        {
            return new()
            {
                StatusCode =
                    RemoveHobbyPermanentlyByHobbyIdResponseStatusCode.HOBBY_IS_NOT_TEMPORARILY_REMOVED
            };
        }

        // Remove hobby permanently by hobby id.
        var result =
            await _unitOfWork.HobbyFeature.RemoveHobbyPermanentlyByHobbyId.Command.RemoveHobbyPermanentlyByHobbyIdCommandAsync(
                hobbyId: request.HobbyId,
                cancellationToken: cancellationToken
            );

        // Database transaction false.
        if (!result)
        {
            return new()
            {
                StatusCode =
                    RemoveHobbyPermanentlyByHobbyIdResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        return new()
        {
            StatusCode = RemoveHobbyPermanentlyByHobbyIdResponseStatusCode.OPERATION_SUCCESS
        };
    }
}
