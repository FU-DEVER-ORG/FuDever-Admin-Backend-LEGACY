using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.User.GetAllUsers;

/// <summary>
///     Get all users request handler.
/// </summary>
internal sealed class GetAllUsersRequestHandler
    : IRequestHandler<GetAllUsersRequest, GetAllUsersResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllUsersRequestHandler(IUnitOfWork unitOfWork)
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
    public async Task<GetAllUsersResponse> Handle(
        GetAllUsersRequest request,
        CancellationToken cancellationToken
    )
    {
        // Get all non temporarily removed users.
        var foundUsers =
            await _unitOfWork.UserFeature.GetAllUsers.Query.GetAllNonTemporarilyRemovedUsersQueryAsync(
                cancellationToken: cancellationToken
            );

        // Project result to response.
        return new()
        {
            StatusCode = GetAllUsersResponseStatusCode.OPERATION_SUCCESS,
            FoundUsers = foundUsers.Select(selector: foundUser =>
            {
                return new GetAllUsersResponse.User()
                {
                    Id = foundUser.Id,
                    FullName = $"{foundUser.LastName} {foundUser.FirstName}".Trim(),
                    Email = foundUser.User.Email,
                    Department = foundUser.Department.Name,
                    Position = foundUser.Position.Name,
                    Status = foundUser.UserJoiningStatus.Type,
                    AvatarUrl = foundUser.AvatarUrl
                };
            })
        };
    }
}
