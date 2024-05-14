using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Shared.Data;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Platform.RestorePlatformByPlatformId;

/// <summary>
///     Restore platform by platform id request handler.
/// </summary>
internal sealed class RestorePlatformByPlatformIdRequestHandler
    : IRequestHandler<RestorePlatformByPlatformIdRequest, RestorePlatformByPlatformIdResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDbMinTimeHandler _dbMinTimeHandler;

    public RestorePlatformByPlatformIdRequestHandler(
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
    public async Task<RestorePlatformByPlatformIdResponse> Handle(
        RestorePlatformByPlatformIdRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is platform found by platform id.
        var isPlatformFoundByPlatformId =
            await _unitOfWork.PlatformFeature.RestorePlatformByPlatformId.Query.IsPlatformFoundByPlatformIdQueryAsync(
                platformId: request.PlatformId,
                cancellationToken: cancellationToken
            );

        // Platform is not found by platform id.
        if (!isPlatformFoundByPlatformId)
        {
            return new()
            {
                StatusCode = RestorePlatformByPlatformIdResponseStatusCode.PLATFORM_IS_NOT_FOUND
            };
        }

        // Is platform temporarily removed by platform id.
        var isPlatformTemporarilyRemoved =
            await _unitOfWork.PlatformFeature.RestorePlatformByPlatformId.Query.IsPlatformTemporarilyRemovedByPlatformIdQueryAsync(
                platformId: request.PlatformId,
                cancellationToken: cancellationToken
            );

        // Platform is not temporarily removed by platform id.
        if (!isPlatformTemporarilyRemoved)
        {
            return new()
            {
                StatusCode =
                    RestorePlatformByPlatformIdResponseStatusCode.PLATFORM_IS_NOT_TEMPORARILY_REMOVED
            };
        }

        // Restore platform by platform id.
        var result =
            await _unitOfWork.PlatformFeature.RestorePlatformByPlatformId.Command.RestorePlatformByPlatformIdCommandAsync(
                platformId: request.PlatformId,
                cancellationToken: cancellationToken
            );

        // Database transaction false.
        if (!result)
        {
            return new()
            {
                StatusCode = RestorePlatformByPlatformIdResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        return new()
        {
            StatusCode = RestorePlatformByPlatformIdResponseStatusCode.OPERATION_SUCCESS
        };
    }
}
