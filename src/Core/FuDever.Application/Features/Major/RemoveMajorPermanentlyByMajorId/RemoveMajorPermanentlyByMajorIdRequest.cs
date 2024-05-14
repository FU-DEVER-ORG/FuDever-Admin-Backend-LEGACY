using System;
using FuDever.Application.Features.Major.RemoveMajorPermanentlyByMajorId.Middlewares;
using MediatR;

namespace FuDever.Application.Features.Major.RemoveMajorPermanentlyByMajorId;

/// <summary>
///     Remove major permanently by major Id request
/// </summary>
public sealed class RemoveMajorPermanentlyByMajorIdRequest
    : IRequest<RemoveMajorPermanentlyByMajorIdResponse>,
        IRemoveMajorPermanentlyByMajorIdMiddleware
{
    public Guid MajorId { get; init; }
}
