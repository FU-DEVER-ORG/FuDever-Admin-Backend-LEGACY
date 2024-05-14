using System;
using FuDever.Application.Features.Platform.UpdatePlatformByPlatformId.Middlewares;
using MediatR;

namespace FuDever.Application.Features.Platform.UpdatePlatformByPlatformId;

/// <summary>
///     Update platform request.
/// </summary>
public sealed class UpdatePlatformByPlatformIdRequest
    : IRequest<UpdatePlatformByPlatformIdResponse>,
        IUpdatePlatformByPlatformIdMiddleware
{
    public Guid PlatformId { get; init; }

    public string NewPlatformName { get; init; }
}
