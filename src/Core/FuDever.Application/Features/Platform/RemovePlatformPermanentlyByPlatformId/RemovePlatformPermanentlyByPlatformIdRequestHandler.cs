using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Platform.RemovePlatformPermanentlyByPlatformId;

/// <summary>
///     Request handler for remove platform permanently by platform id.
/// </summary>
internal sealed class RemovePlatformPermanentlyByPlatformIdRequestHandler
    : IRequestHandler<
        RemovePlatformPermanentlyByPlatformIdRequest,
        RemovePlatformPermanentlyByPlatformIdResponse
    >
{
    private readonly IUnitOfWork _unitOfWork;

    public RemovePlatformPermanentlyByPlatformIdRequestHandler(IUnitOfWork unitOfWork)
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
    public async Task<RemovePlatformPermanentlyByPlatformIdResponse> Handle(
        RemovePlatformPermanentlyByPlatformIdRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is platform found by platform id.
        var isPlatformFoundByPlatformId =
            await _unitOfWork.PlatformFeature.RemovePlatformPermanentlyByPlatformId.Query.IsPlatformFoundByPlatformIdQueryAsync(
                platformId: request.PlatformId,
                cancellationToken: cancellationToken
            );

        // Platform is not found by platform id.
        if (!isPlatformFoundByPlatformId)
        {
            return new()
            {
                StatusCode =
                    RemovePlatformPermanentlyByPlatformIdResponseStatusCode.PLATFORM_IS_NOT_FOUND
            };
        }

        // Is platform temporarily removed by platform id.
        var isPlatformTemporarilyRemoved =
            await _unitOfWork.PlatformFeature.RemovePlatformPermanentlyByPlatformId.Query.IsPlatformTemporarilyRemovedByPlatformIdQueryAsync(
                platformId: request.PlatformId,
                cancellationToken: cancellationToken
            );

        // Platform is not temporarily removed by platform id.
        if (!isPlatformTemporarilyRemoved)
        {
            return new()
            {
                StatusCode =
                    RemovePlatformPermanentlyByPlatformIdResponseStatusCode.PLATFORM_IS_NOT_TEMPORARILY_REMOVED
            };
        }

        // Remove platform permanently by platform id.
        var result =
            await _unitOfWork.PlatformFeature.RemovePlatformPermanentlyByPlatformId.Command.RemovePlatformPermanentlyByPlatformIdCommandAsync(
                platformId: request.PlatformId,
                cancellationToken: cancellationToken
            );

        // Database transaction false.
        if (!result)
        {
            return new()
            {
                StatusCode =
                    RemovePlatformPermanentlyByPlatformIdResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        return new()
        {
            StatusCode = RemovePlatformPermanentlyByPlatformIdResponseStatusCode.OPERATION_SUCCESS
        };
    }
}
