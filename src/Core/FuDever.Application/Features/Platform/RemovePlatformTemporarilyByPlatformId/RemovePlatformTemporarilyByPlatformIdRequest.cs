using System;
using FuDever.Application.Features.Platform.RemovePlatformTemporarilyByPlatformId.Middlewares;
using MediatR;

namespace FuDever.Application.Features.Platform.RemovePlatformTemporarilyByPlatformId;

/// <summary>
///     Remove platform temporarily by platfrom id request.
/// </summary>
public sealed class RemovePlatformTemporarilyByPlatformIdRequest
    : IRequest<RemovePlatformTemporarilyByPlatformIdResponse>,
        IRemovePlatformTemporarilyByPlatformIdMiddleware
{
    public Guid PlatformId { get; init; }
}
