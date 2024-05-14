using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Role.GetAllRolesByRoleName;

/// <summary>
///     Get all roles by role name request handler.
/// </summary>
internal sealed class GetAllRolesByRoleNameRequestHandler
    : IRequestHandler<GetAllRolesByRoleNameRequest, GetAllRolesByRoleNameResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllRolesByRoleNameRequestHandler(IUnitOfWork unitOfWork)
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
    public async Task<GetAllRolesByRoleNameResponse> Handle(
        GetAllRolesByRoleNameRequest request,
        CancellationToken cancellationToken
    )
    {
        // Get all roles by role name.
        var foundRoles =
            await _unitOfWork.RoleFeature.GetAllRolesByRoleName.Query.GetAllRolesByRoleNameQueryAsync(
                roleName: request.RoleName,
                cancellationToken: cancellationToken
            );

        // Project result to response.
        return new()
        {
            StatusCode = GetAllRolesByRoleNameResponseStatusCode.OPERATION_SUCCESS,
            FoundRoles = foundRoles.Select(selector: foundRole =>
            {
                return new GetAllRolesByRoleNameResponse.Role()
                {
                    RoleId = foundRole.Id,
                    RoleName = foundRole.Name
                };
            })
        };
    }
}
