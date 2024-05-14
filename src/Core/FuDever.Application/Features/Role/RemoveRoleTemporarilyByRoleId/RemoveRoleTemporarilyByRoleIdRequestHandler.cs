using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.JsonWebTokens;

namespace FuDever.Application.Features.Role.RemoveRoleTemporarilyByRoleId;

/// <summary>
///     Remove role temporarily by role id request handler.
/// </summary>
internal sealed class RemoveRoleTemporarilyByRoleIdRequestHandler
    : IRequestHandler<RemoveRoleTemporarilyByRoleIdRequest, RemoveRoleTemporarilyByRoleIdResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public RemoveRoleTemporarilyByRoleIdRequestHandler(
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor
    )
    {
        _unitOfWork = unitOfWork;
        _httpContextAccessor = httpContextAccessor;
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
    public async Task<RemoveRoleTemporarilyByRoleIdResponse> Handle(
        RemoveRoleTemporarilyByRoleIdRequest request,
        CancellationToken cancellationToken
    )
    {
        // Is role found by role id.
        var isRoleFound =
            await _unitOfWork.RoleFeature.RemoveRoleTemporarilyByRoleId.Query.IsRoleFoundByRoleIdQueryAsync(
                roleId: request.RoleId,
                cancellationToken: cancellationToken
            );

        // Role is not found by role id.
        if (!isRoleFound)
        {
            return new()
            {
                StatusCode = RemoveRoleTemporarilyByRoleIdResponseStatusCode.ROLE_IS_NOT_FOUND
            };
        }

        // Is role temporarily removed by role id.
        var isRoleTemporarilyRemoved =
            await _unitOfWork.RoleFeature.RemoveRoleTemporarilyByRoleId.Query.IsRoleTemporarilyRemovedByRoleIdQueryAsync(
                roleId: request.RoleId,
                cancellationToken: cancellationToken
            );

        // Role is already temporarily removed by role id.
        if (isRoleTemporarilyRemoved)
        {
            return new()
            {
                StatusCode =
                    RemoveRoleTemporarilyByRoleIdResponseStatusCode.ROLE_IS_ALREADY_TEMPORARILY_REMOVED
            };
        }

        // Remove role temporarily by role id.
        var result =
            await _unitOfWork.RoleFeature.RemoveRoleTemporarilyByRoleId.Command.RemoveRoleTemporarilyByRoleIdCommandAsync(
                roleId: request.RoleId,
                removedAt: DateTime.UtcNow,
                removedBy: Guid.Parse(
                    input: _httpContextAccessor.HttpContext.User.FindFirstValue(
                        claimType: JwtRegisteredClaimNames.Sub
                    )
                ),
                cancellationToken: cancellationToken
            );

        // Database transaction false.
        if (!result)
        {
            return new()
            {
                StatusCode = RemoveRoleTemporarilyByRoleIdResponseStatusCode.DATABASE_OPERATION_FAIL
            };
        }

        return new()
        {
            StatusCode = RemoveRoleTemporarilyByRoleIdResponseStatusCode.OPERATION_SUCCESS
        };
    }
}
