using System;
using FuDever.Application.Features.Role.RemoveRolePermanentlyByRoleId.Middlewares;
using MediatR;

namespace FuDever.Application.Features.Role.RemoveRolePermanentlyByRoleId;

/// <summary>
///     Remove role permanently by role id request.
/// </summary>
public sealed class RemoveRolePermanentlyByRoleIdRequest
    : IRequest<RemoveRolePermanentlyByRoleIdResponse>,
        IRemoveRolePermanentlyByRoleIdMiddleware
{
    public Guid RoleId { get; init; }
}
