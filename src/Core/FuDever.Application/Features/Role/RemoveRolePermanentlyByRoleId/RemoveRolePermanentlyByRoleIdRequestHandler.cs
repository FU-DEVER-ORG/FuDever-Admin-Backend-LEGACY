using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Role.RemoveRolePermanentlyByRoleId;

/// <summary>
///     Remove role permanently by role id request handler.
/// </summary>
internal sealed class RemoveRolePermanentlyByRoleIdRequestHandler
    : IRequestHandler<RemoveRolePermanentlyByRoleIdRequest, RemoveRolePermanentlyByRoleIdResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveRolePermanentlyByRoleIdRequestHandler(IUnitOfWork unitOfWork)
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
    public async Task<RemoveRolePermanentlyByRoleIdResponse> Handle(
        RemoveRolePermanentlyByRoleIdRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is role found by role id.
        var isRoleFoundByRoleId =
            await _unitOfWork.RoleFeature.RemoveRolePermanentlyByRoleId.Query.IsRoleFoundByRoleIdQueryAsync(
                roleId: request.RoleId,
                cancellationToken: cancellationToken
            );

        // Role is not found by role id.
        if (!isRoleFoundByRoleId)
        {
            return new()
            {
                StatusCode = RemoveRolePermanentlyByRoleIdResponseStatusCode.ROLE_IS_NOT_FOUND
            };
        }

        // Is role temporarily removed by role id.
        var isRoleTemporarilyRemoved =
            await _unitOfWork.RoleFeature.RemoveRolePermanentlyByRoleId.Query.IsRoleTemporarilyRemovedByRoleIdQueryAsync(
                roleId: request.RoleId,
                cancellationToken: cancellationToken
            );

        // Role is not temporarily removed by role id.
        if (!isRoleTemporarilyRemoved)
        {
            return new()
            {
                StatusCode =
                    RemoveRolePermanentlyByRoleIdResponseStatusCode.ROLE_IS_NOT_TEMPORARILY_REMOVED
            };
        }

        // Remove role permanently by role id.
        var result =
            await _unitOfWork.RoleFeature.RemoveRolePermanentlyByRoleId.Command.RemoveRolePermanentlyByRoleIdCommandAsync(
                roleId: request.RoleId,
                cancellationToken: cancellationToken
            );

        // Database transaction false.
        if (!result)
        {
            return new()
            {
                StatusCode = RemoveRolePermanentlyByRoleIdResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        return new()
        {
            StatusCode = RemoveRolePermanentlyByRoleIdResponseStatusCode.OPERATION_SUCCESS
        };
    }
}
