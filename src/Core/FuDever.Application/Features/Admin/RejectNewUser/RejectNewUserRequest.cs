using System;
using FuDever.Application.Features.Admin.RejectNewUser.Middlewares;
using MediatR;

namespace FuDever.Application.Features.Admin.RejectNewUser;

/// <summary>
///     Request of reject new user feature.
/// </summary>
public sealed class RejectNewUserRequest : IRequest<RejectNewUserResponse>, IRejectNewUserMiddleware
{
    public Guid UserId { get; init; }
}
