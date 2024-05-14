using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Platform.GetAllPlatforms;

/// <summary>
///     Get all platforms request handler.
/// </summary>
internal sealed class GetAllPlatformsRequestHandler
    : IRequestHandler<GetAllPlatformsRequest, GetAllPlatformsResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPlatformsRequestHandler(IUnitOfWork unitOfWork)
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
    public async Task<GetAllPlatformsResponse> Handle(
        GetAllPlatformsRequest request,
        CancellationToken cancellationToken
    )
    {
        // Get all non temporarily removed platforms.
        var foundPlatforms =
            await _unitOfWork.PlatformFeature.GetAllPlatforms.Query.GetAllNonTemporarilyRemovedPlatformsQueryAsync(
                cancellationToken: cancellationToken
            );

        // Project result to response.
        return new()
        {
            StatusCode = GetAllPlatformsResponseStatusCode.OPERATION_SUCCESS,
            FoundPlatforms = foundPlatforms.Select(selector: foundPlatform =>
            {
                return new GetAllPlatformsResponse.Platform()
                {
                    PlatformId = foundPlatform.Id,
                    PlatformName = foundPlatform.Name
                };
            })
        };
    }
}
