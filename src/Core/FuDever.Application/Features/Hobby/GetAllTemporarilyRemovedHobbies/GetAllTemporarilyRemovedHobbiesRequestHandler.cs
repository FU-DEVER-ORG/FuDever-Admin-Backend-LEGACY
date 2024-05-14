using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Hobby.GetAllTemporarilyRemovedHobbies;

/// <summary>
///     Get all temporarily removed hobbies request handler.
/// </summary>
internal sealed class GetAllTemporarilyRemovedHobbiesRequestHandler
    : IRequestHandler<
        GetAllTemporarilyRemovedHobbiesRequest,
        GetAllTemporarilyRemovedHobbiesResponse
    >
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTemporarilyRemovedHobbiesRequestHandler(IUnitOfWork unitOfWork)
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
    public async Task<GetAllTemporarilyRemovedHobbiesResponse> Handle(
        GetAllTemporarilyRemovedHobbiesRequest request,
        CancellationToken cancellationToken
    )
    {
        // Get all temporarily removed hobbies.
        var foundTemporarilyRemovedHobbies =
            await _unitOfWork.HobbyFeature.GetAllTemporarilyRemovedHobbies.Query.GetAllTemporarilyRemovedHobbiesQueryAsync(
                cancellationToken: cancellationToken
            );

        // Project result to response.
        return new()
        {
            StatusCode = GetAllTemporarilyRemovedHobbiesResponseStatusCode.OPERATION_SUCCESS,
            FoundTemporarilyRemovedHobbies = foundTemporarilyRemovedHobbies.Select(
                selector: foundHobby =>
                {
                    return new GetAllTemporarilyRemovedHobbiesResponse.Hobby()
                    {
                        HobbyId = foundHobby.Id,
                        HobbyName = foundHobby.Name,
                        HobbyRemovedAt = foundHobby.RemovedAt,
                        HobbyRemovedBy = foundHobby.RemovedBy
                    };
                }
            )
        };
    }
}
