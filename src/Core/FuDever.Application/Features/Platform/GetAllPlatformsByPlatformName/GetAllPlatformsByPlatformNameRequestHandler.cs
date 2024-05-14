using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Platform.GetAllPlatformsByPlatformName;

/// <summary>
///     Get all platforms by name request handler.
/// </summary>
internal sealed class GetAllPlatformsByPlatformNameRequestHandler
    : IRequestHandler<GetAllPlatformsByPlatformNameRequest, GetAllPlatformsByPlatformNameResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPlatformsByPlatformNameRequestHandler(IUnitOfWork unitOfWork)
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
    /// </param>
    /// <returns>
    ///     A task containing the boolean result.
    /// </returns>
    public async Task<GetAllPlatformsByPlatformNameResponse> Handle(
        GetAllPlatformsByPlatformNameRequest request,
        CancellationToken cancellationToken
    )
    {
        // Get all platforms by name.
        var foundPlatforms =
            await _unitOfWork.PlatformFeature.GetAllPlatformsByPlatformName.Query.GetAllPlatformsByPlatformNameQueryAsync(
                platformName: request.PlatformName,
                cancellationToken: cancellationToken
            );

        return new()
        {
            StatusCode = GetAllPlatformsByPlatformNameResponseStatusCode.OPERATION_SUCCESS,
            FoundPlatforms = foundPlatforms.Select(selector: foundPlatform =>
            {
                return new GetAllPlatformsByPlatformNameResponse.Platform()
                {
                    PlatformId = foundPlatform.Id,
                    PlatformName = foundPlatform.Name
                };
            }),
        };
    }
}
