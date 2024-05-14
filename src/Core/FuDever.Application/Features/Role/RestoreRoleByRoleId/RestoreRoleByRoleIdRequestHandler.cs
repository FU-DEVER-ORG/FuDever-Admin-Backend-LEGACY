using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Shared.Data;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Role.RestoreRoleByRoleId;

/// <summary>
///     Restore role by role id request handler.
/// </summary>
internal sealed class RestoreRoleByRoleIdRequestHandler
    : IRequestHandler<RestoreRoleByRoleIdRequest, RestoreRoleByRoleIdResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDbMinTimeHandler _dbMinTimeHandler;

    public RestoreRoleByRoleIdRequestHandler(
        IUnitOfWork unitOfWork,
        IDbMinTimeHandler dbMinTimeHandler
    )
    {
        _unitOfWork = unitOfWork;
        _dbMinTimeHandler = dbMinTimeHandler;
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
    public async Task<RestoreRoleByRoleIdResponse> Handle(
        RestoreRoleByRoleIdRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is role found by role id.
        var isRoleFoundByRoleId =
            await _unitOfWork.RoleFeature.RestoreRoleByRoleId.Query.IsRoleFoundByRoleIdQueryAsync(
                roleId: request.RoleId,
                cancellationToken: cancellationToken
            );

        // Role is not found by role id.
        if (!isRoleFoundByRoleId)
        {
            return new() { StatusCode = RestoreRoleByRoleIdResponseStatusCode.ROLE_IS_NOT_FOUND };
        }

        // Is role temporarily removed by role id.
        var isRoleTemporarilyRemoved =
            await _unitOfWork.RoleFeature.RestoreRoleByRoleId.Query.IsRoleTemporarilyRemovedByRoleIdQueryAsync(
                roleId: request.RoleId,
                cancellationToken: cancellationToken
            );

        // Role is not temporarily removed by role id.
        if (!isRoleTemporarilyRemoved)
        {
            return new()
            {
                StatusCode = RestoreRoleByRoleIdResponseStatusCode.ROLE_IS_NOT_TEMPORARILY_REMOVED
            };
        }

        // Remove role permanently by role id.
        var result =
            await _unitOfWork.RoleFeature.RestoreRoleByRoleId.Command.RestoreRoleByRoleIdCommandAsync(
                roleId: request.RoleId,
                cancellationToken: cancellationToken
            );

        // Database transaction false.
        if (!result)
        {
            return new()
            {
                StatusCode = RestoreRoleByRoleIdResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        return new() { StatusCode = RestoreRoleByRoleIdResponseStatusCode.OPERATION_SUCCESS };
    }
}
