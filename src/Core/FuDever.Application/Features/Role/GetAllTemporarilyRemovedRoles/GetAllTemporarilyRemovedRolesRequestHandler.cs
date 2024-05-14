using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Role.GetAllTemporarilyRemovedRoles;

/// <summary>
///     Get all temporarily removed roles request handler.
/// </summary>
internal sealed class GetAllTemporarilyRemovedRolesRequestHandler
    : IRequestHandler<GetAllTemporarilyRemovedRolesRequest, GetAllTemporarilyRemovedRolesResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTemporarilyRemovedRolesRequestHandler(IUnitOfWork unitOfWork)
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
    public async Task<GetAllTemporarilyRemovedRolesResponse> Handle(
        GetAllTemporarilyRemovedRolesRequest request,
        CancellationToken cancellationToken
    )
    {
        // Get all temporarily removed roles.
        var foundTemporarilyRemovedRoles =
            await _unitOfWork.RoleFeature.GetAllTemporarilyRemovedRoles.Query.GetAllTemporarilyRemovedRolesQueryAsync(
                cancellationToken: cancellationToken
            );

        // Project result to response.
        return new()
        {
            StatusCode = GetAllTemporarilyRemovedRolesResponseStatusCode.OPERATION_SUCCESS,
            FoundTemporarilyRemovedRoles = foundTemporarilyRemovedRoles.Select(
                selector: foundRole =>
                {
                    return new GetAllTemporarilyRemovedRolesResponse.Role()
                    {
                        RoleId = foundRole.Id,
                        RoleName = foundRole.Name,
                        RoleRemovedAt = foundRole.RemovedAt,
                        RoleRemovedBy = foundRole.RemovedBy
                    };
                }
            )
        };
    }
}
