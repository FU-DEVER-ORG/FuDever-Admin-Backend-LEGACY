using System;
using FuDever.Application.Features.Admin.ApproveNewUser.Middlewares;
using MediatR;

namespace FuDever.Application.Features.Admin.ApproveNewUser;

/// <summary>
///     Approve new user request.
/// </summary>
public sealed class ApproveNewUserRequest
    : IRequest<ApproveNewUserResponse>,
        IApproveNewUserMiddleware
{
    public Guid UserId { get; init; }
}
