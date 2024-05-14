using System;
using FuDever.Application.Features.Platform.RemovePlatformPermanentlyByPlatformId.Middlewares;
using MediatR;

namespace FuDever.Application.Features.Platform.RemovePlatformPermanentlyByPlatformId;

/// <summary>
///     Request for remove platform permanently by platform id.
/// </summary>
public sealed class RemovePlatformPermanentlyByPlatformIdRequest
    : IRequest<RemovePlatformPermanentlyByPlatformIdResponse>,
        IRemovePlatformPermanentlyByPlatformIdMiddleware
{
    public Guid PlatformId { get; init; }
}
