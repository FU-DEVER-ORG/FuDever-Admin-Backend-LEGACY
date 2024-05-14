using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Hobby.GetAllHobbies;

/// <summary>
///     Get all hobbies request handler.
/// </summary>
internal sealed class GetAllHobbiesRequestHandler
    : IRequestHandler<GetAllHobbiesRequest, GetAllHobbiesResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllHobbiesRequestHandler(IUnitOfWork unitOfWork)
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
    public async Task<GetAllHobbiesResponse> Handle(
        GetAllHobbiesRequest request,
        CancellationToken cancellationToken
    )
    {
        // Get all non temporarily removed hobbies.
        var foundHobbies =
            await _unitOfWork.HobbyFeature.GetAllHobbies.Query.GetAllNonTemporarilyRemovedHobbiesQueryAsync(
                cancellationToken: cancellationToken
            );

        // Project result to response.
        return new()
        {
            StatusCode = GetAllHobbiesResponseStatusCode.OPERATION_SUCCESS,
            FoundHobbies = foundHobbies.Select(selector: foundHobby =>
            {
                return new GetAllHobbiesResponse.Hobby()
                {
                    HobbyId = foundHobby.Id,
                    HobbyName = foundHobby.Name
                };
            })
        };
    }
}
