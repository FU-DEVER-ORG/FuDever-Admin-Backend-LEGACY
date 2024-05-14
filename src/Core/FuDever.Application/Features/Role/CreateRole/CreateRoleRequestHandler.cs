using System;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Shared.Data;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Role.CreateRole;

/// <summary>
///     Create role request handler.
/// </summary>
internal sealed class CreateRoleRequestHandler
    : IRequestHandler<CreateRoleRequest, CreateRoleResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDbMinTimeHandler _dbMinTimeHandler;

    public CreateRoleRequestHandler(IUnitOfWork unitOfWork, IDbMinTimeHandler dbMinTimeHandler)
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
    public async Task<CreateRoleResponse> Handle(
        CreateRoleRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is role with the same role name found.
        var isRoleFound =
            await _unitOfWork.RoleFeature.CreateRole.Query.IsRoleWithTheSameNameFoundByRoleNameQueryAsync(
                newRoleName: request.NewRoleName,
                cancellationToken: cancellationToken
            );

        // Roles with the same role name is found.
        if (isRoleFound)
        {
            // Is role temporarily removed by role name.
            var isRoleTemporarilyRemoved =
                await _unitOfWork.RoleFeature.CreateRole.Query.IsRoleTemporarilyRemovedByRoleNameQueryAsync(
                    newRoleName: request.NewRoleName,
                    cancellationToken: cancellationToken
                );

            // Role with role name is already temporarily removed.
            if (isRoleTemporarilyRemoved)
            {
                return new()
                {
                    StatusCode = CreateRoleResponseStatusCode.ROLE_IS_ALREADY_TEMPORARILY_REMOVED
                };
            }

            return new() { StatusCode = CreateRoleResponseStatusCode.ROLE_ALREADY_EXISTS };
        }

        // Create role with new role name.
        var result = await _unitOfWork.RoleFeature.CreateRole.Command.CreateRoleCommandAsync(
            newRole: InitNewRole(request.NewRoleName),
            cancellationToken: cancellationToken
        );

        // Database transaction false.
        if (!result)
        {
            return new() { StatusCode = CreateRoleResponseStatusCode.DATABASE_OPERATION_FAIL };
        }

        return new() { StatusCode = CreateRoleResponseStatusCode.OPERATION_SUCCESS };
    }

    #region Others
    private Domain.Entities.Role InitNewRole(string newRoleName)
    {
        return new()
        {
            Id = Guid.NewGuid(),
            Name = newRoleName,
            RemovedAt = _dbMinTimeHandler.Get(),
            RemovedBy = Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
        };
    }
    #endregion
}
