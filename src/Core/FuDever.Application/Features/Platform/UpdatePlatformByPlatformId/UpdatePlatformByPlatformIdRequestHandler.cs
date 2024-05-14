using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Platform.UpdatePlatformByPlatformId;

/// <summary>
///     Update platform by platform id request handler.
/// </summary>
internal sealed class UpdatePlatformByPlatformIdRequestHandler
    : IRequestHandler<UpdatePlatformByPlatformIdRequest, UpdatePlatformByPlatformIdResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePlatformByPlatformIdRequestHandler(IUnitOfWork unitOfWork)
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
    public async Task<UpdatePlatformByPlatformIdResponse> Handle(
        UpdatePlatformByPlatformIdRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is platform found by platform id.
        var isPlatformFoundByPlatformId =
            await _unitOfWork.PlatformFeature.UpdatePlatformByPlatformId.Query.IsPlatformFoundByPlatformIdQueryAsync(
                platformId: request.PlatformId,
                cancellationToken: cancellationToken
            );

        // Platform is not found by platform id.
        if (!isPlatformFoundByPlatformId)
        {
            return new()
            {
                StatusCode = UpdatePlatformByPlatformIdResponseStatusCode.PLATFORM_IS_NOT_FOUND
            };
        }

        // Is platform temporarily removed by platform id.
        var isPlatformTemporarilyRemoved =
            await _unitOfWork.PlatformFeature.UpdatePlatformByPlatformId.Query.IsPlatformTemporarilyRemovedByPlatformIdQueryAsync(
                platformId: request.PlatformId,
                cancellationToken: cancellationToken
            );

        // Platform is already temporarily removed by platform id.
        if (isPlatformTemporarilyRemoved)
        {
            return new()
            {
                StatusCode =
                    UpdatePlatformByPlatformIdResponseStatusCode.PLATFORM_IS_ALREADY_TEMPORARILY_REMOVED
            };
        }

        // Is platform with the same platform name found.
        var isPlatformWithTheSameNameFound =
            await _unitOfWork.PlatformFeature.UpdatePlatformByPlatformId.Query.IsPlatformWithTheSameNameFoundByPlatformNameQueryAsync(
                newPlatformName: request.NewPlatformName,
                cancellationToken: cancellationToken
            );

        // Platform with the same platform name is found.
        if (isPlatformWithTheSameNameFound)
        {
            return new()
            {
                StatusCode = UpdatePlatformByPlatformIdResponseStatusCode.PLATFORM_ALREADY_EXISTS
            };
        }

        // Update platform by platform id.
        var result =
            await _unitOfWork.PlatformFeature.UpdatePlatformByPlatformId.Command.UpdatePlatformByPlatformIdCommandAsync(
                platformId: request.PlatformId,
                newPlatformName: request.NewPlatformName,
                cancellationToken: cancellationToken
            );

        // Database transaction false.
        if (!result)
        {
            return new()
            {
                StatusCode = UpdatePlatformByPlatformIdResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        return new()
        {
            StatusCode = UpdatePlatformByPlatformIdResponseStatusCode.OPERATION_SUCCESS
        };
    }
}
