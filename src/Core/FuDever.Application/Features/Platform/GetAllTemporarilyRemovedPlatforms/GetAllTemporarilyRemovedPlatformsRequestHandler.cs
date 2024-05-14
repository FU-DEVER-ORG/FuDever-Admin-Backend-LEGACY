using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Platform.GetAllTemporarilyRemovedPlatforms;

/// <summary>
///     Get all temporarily removed platforms request handler.
/// </summary>
internal sealed class GetAllTemporarilyRemovedPlatformsRequestHandler
    : IRequestHandler<
        GetAllTemporarilyRemovedPlatformsRequest,
        GetAllTemporarilyRemovedPlatformsResponse
    >
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTemporarilyRemovedPlatformsRequestHandler(IUnitOfWork unitOfWork)
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
    public async Task<GetAllTemporarilyRemovedPlatformsResponse> Handle(
        GetAllTemporarilyRemovedPlatformsRequest request,
        CancellationToken cancellationToken
    )
    {
        // Get all temporarily removed platforms.
        var foundTemporarilyRemovedPlatforms =
            await _unitOfWork.PlatformFeature.GetAllTemporarilyRemovedPlatforms.Query.GetAllTemporarilyRemovedPlatformsQueryAsync(
                cancellationToken: cancellationToken
            );

        // Project result to response.
        return new()
        {
            StatusCode = GetAllTemporarilyRemovedPlatformsResponseStatusCode.OPERATION_SUCCESS,
            FoundTemporarilyRemovedPlatforms = foundTemporarilyRemovedPlatforms.Select(
                selector: foundPlatform =>
                {
                    return new GetAllTemporarilyRemovedPlatformsResponse.Platform()
                    {
                        PlatformId = foundPlatform.Id,
                        PlatformName = foundPlatform.Name,
                        PlatformRemovedAt = foundPlatform.RemovedAt,
                        PlatformRemovedBy = foundPlatform.RemovedBy
                    };
                }
            )
        };
    }
}
