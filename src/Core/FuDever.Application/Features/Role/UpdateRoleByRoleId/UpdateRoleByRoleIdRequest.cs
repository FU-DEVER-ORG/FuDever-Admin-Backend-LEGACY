using System;
using FuDever.Application.Features.Role.UpdateRoleByRoleId.Middlewares;
using MediatR;

namespace FuDever.Application.Features.Role.UpdateRoleByRoleId;

/// <summary>
///     Update role by role id request.
/// </summary>
public sealed class UpdateRoleByRoleIdRequest
    : IRequest<UpdateRoleByRoleIdResponse>,
        IUpdateRoleByRoleIdMiddleware
{
    public Guid RoleId { get; init; }

    public string NewRoleName { get; init; }
}
