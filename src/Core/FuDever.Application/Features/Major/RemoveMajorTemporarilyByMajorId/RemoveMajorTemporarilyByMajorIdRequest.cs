using System;
using FuDever.Application.Features.Major.RemoveMajorTemporarilyByMajorId.Middlewares;
using MediatR;

namespace FuDever.Application.Features.Major.RemoveMajorTemporarilyByMajorId;

/// <summary>
///     Remove major temporarily by major id request.
/// </summary>
public sealed class RemoveMajorTemporarilyByMajorIdRequest
    : IRequest<RemoveMajorTemporarilyByMajorIdResponse>,
        IRemoveMajorTemporarilyByMajorIdMiddleware
{
    public Guid MajorId { get; init; }
}
