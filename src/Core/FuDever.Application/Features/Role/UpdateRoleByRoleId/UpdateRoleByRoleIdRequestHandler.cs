using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Role.UpdateRoleByRoleId;

/// <summary>
///     Update role by role id request handler.
/// </summary>
internal sealed class UpdateRoleByRoleIdRequestHandler
    : IRequestHandler<UpdateRoleByRoleIdRequest, UpdateRoleByRoleIdResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRoleByRoleIdRequestHandler(IUnitOfWork unitOfWork)
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
    public async Task<UpdateRoleByRoleIdResponse> Handle(
        UpdateRoleByRoleIdRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is role found by role id.
        var isRoleFoundByRoleId =
            await _unitOfWork.RoleFeature.UpdateRoleByRoleId.Query.IsRoleFoundByRoleIdQueryAsync(
                roleId: request.RoleId,
                cancellationToken: cancellationToken
            );

        // Role is not found by role id.
        if (!isRoleFoundByRoleId)
        {
            return new() { StatusCode = UpdateRoleByRoleIdResponseStatusCode.ROLE_IS_NOT_FOUND };
        }

        // Is role temporarily removed by role id.
        var isRoleTemporarilyRemoved =
            await _unitOfWork.RoleFeature.UpdateRoleByRoleId.Query.IsRoleTemporarilyRemovedByRoleIdQueryAsync(
                roleId: request.RoleId,
                cancellationToken: cancellationToken
            );

        // Role is already temporarily removed by role id.
        if (isRoleTemporarilyRemoved)
        {
            return new()
            {
                StatusCode =
                    UpdateRoleByRoleIdResponseStatusCode.ROLE_IS_ALREADY_TEMPORARILY_REMOVED
            };
        }

        // Is role with the same role name found.
        var isRoleWithTheSameNameFound =
            await _unitOfWork.RoleFeature.UpdateRoleByRoleId.Query.IsRoleWithTheSameNameFoundByRoleNameQueryAsync(
                newRoleName: request.NewRoleName,
                cancellationToken: cancellationToken
            );

        // Role with the same role name is found.
        if (isRoleWithTheSameNameFound)
        {
            return new() { StatusCode = UpdateRoleByRoleIdResponseStatusCode.ROLE_ALREADY_EXISTS };
        }

        // Update role by role id.
        var result =
            await _unitOfWork.RoleFeature.UpdateRoleByRoleId.Command.UpdateRoleByRoleIdCommandAsync(
                roleId: request.RoleId,
                newRoleName: request.NewRoleName,
                cancellationToken: cancellationToken
            );

        // Database transaction false.
        if (!result)
        {
            return new()
            {
                StatusCode = UpdateRoleByRoleIdResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        return new() { StatusCode = UpdateRoleByRoleIdResponseStatusCode.OPERATION_SUCCESS };
    }
}
