using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Major.RemoveMajorPermanentlyByMajorId;

/// <summary>
///     Remove major permanently by major Id request handler.
/// </summary>
internal sealed class RemoveMajorPermanentlyByMajorIdRequestHandler
    : IRequestHandler<
        RemoveMajorPermanentlyByMajorIdRequest,
        RemoveMajorPermanentlyByMajorIdResponse
    >
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveMajorPermanentlyByMajorIdRequestHandler(IUnitOfWork unitOfWork)
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
    public async Task<RemoveMajorPermanentlyByMajorIdResponse> Handle(
        RemoveMajorPermanentlyByMajorIdRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is major found by major id.
        var isMajorFoundByMajorId =
            await _unitOfWork.MajorFeature.RemoveMajorPermanentlyByMajorId.Query.IsMajorFoundByMajorIdQueryAsync(
                majorId: request.MajorId,
                cancellationToken: cancellationToken
            );

        // Major is not found by major id.
        if (!isMajorFoundByMajorId)
        {
            return new()
            {
                StatusCode = RemoveMajorPermanentlyByMajorIdResponseStatusCode.MAJOR_IS_NOT_FOUND
            };
        }

        // Is major temporarily removed by major id.
        var isMajorTemporarilyRemoved =
            await _unitOfWork.MajorFeature.RemoveMajorPermanentlyByMajorId.Query.IsMajorTemporarilyRemovedByMajorIdQueryAsync(
                majorId: request.MajorId,
                cancellationToken: cancellationToken
            );

        // Major is not temporarily removed by major id.
        if (!isMajorTemporarilyRemoved)
        {
            return new()
            {
                StatusCode =
                    RemoveMajorPermanentlyByMajorIdResponseStatusCode.MAJOR_IS_NOT_TEMPORARILY_REMOVED
            };
        }

        // Remove major permanently by major id.
        var result =
            await _unitOfWork.MajorFeature.RemoveMajorPermanentlyByMajorId.Command.RemoveMajorPermanentlyByMajorIdCommandAsync(
                majorId: request.MajorId,
                cancellationToken: cancellationToken
            );

        // Database transaction false.
        if (!result)
        {
            return new()
            {
                StatusCode =
                    RemoveMajorPermanentlyByMajorIdResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        return new()
        {
            StatusCode = RemoveMajorPermanentlyByMajorIdResponseStatusCode.OPERATION_SUCCESS
        };
    }
}
