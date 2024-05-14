using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Role.GetAllRoles;

/// <summary>
///     Get all role request handler.
/// </summary>
internal sealed class GetAllRolesRequestHandler
    : IRequestHandler<GetAllRolesRequest, GetAllRolesResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllRolesRequestHandler(IUnitOfWork unitOfWork)
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
    public async Task<GetAllRolesResponse> Handle(
        GetAllRolesRequest request,
        CancellationToken cancellationToken
    )
    {
        // Get all non temporarily removed roles.
        var foundRoles =
            await _unitOfWork.RoleFeature.GetAllRoles.Query.GetAllNonTemporarilyRemovedRolesQueryAsync(
                cancellationToken: cancellationToken
            );

        // Project result to response.
        return new()
        {
            StatusCode = GetAllRolesResponseStatusCode.OPERATION_SUCCESS,
            FoundRoles = foundRoles.Select(selector: foundRole =>
            {
                return new GetAllRolesResponse.Role()
                {
                    RoleId = foundRole.Id,
                    RoleName = foundRole.Name
                };
            })
        };
    }
}
