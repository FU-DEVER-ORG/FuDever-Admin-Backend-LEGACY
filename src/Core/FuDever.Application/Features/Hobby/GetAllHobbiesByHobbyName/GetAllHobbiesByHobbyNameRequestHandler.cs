using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Hobby.GetAllHobbiesByHobbyName;

/// <summary>
///     Request handler for getting all hobbies by hobby name.
/// </summary>
internal sealed class GetAllHobbiesByHobbyNameRequestHandler
    : IRequestHandler<GetAllHobbiesByHobbyNameRequest, GetAllHobbiesByHobbyNameResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllHobbiesByHobbyNameRequestHandler(IUnitOfWork unitOfWork)
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
    public async Task<GetAllHobbiesByHobbyNameResponse> Handle(
        GetAllHobbiesByHobbyNameRequest request,
        CancellationToken cancellationToken
    )
    {
        // Get all hobbies by name.
        var foundHobbies =
            await _unitOfWork.HobbyFeature.GetAllHobbiesByHobbyName.Query.GetAllHobbiesByHobbyNameQueryAsync(
                hobbyName: request.HobbyName,
                cancellationToken: cancellationToken
            );

        return new()
        {
            StatusCode = GetAllHobbiesByHobbyNameResponseStatusCode.OPERATION_SUCCESS,
            FoundHobbies = foundHobbies.Select(selector: foundHobby =>
            {
                return new GetAllHobbiesByHobbyNameResponse.Hobby()
                {
                    HobbyId = foundHobby.Id,
                    HobbyName = foundHobby.Name
                };
            }),
        };
    }
}
