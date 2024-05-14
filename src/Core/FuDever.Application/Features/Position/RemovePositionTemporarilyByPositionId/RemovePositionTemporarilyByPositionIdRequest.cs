using System;
using FuDever.Application.Features.Position.RemovePositionTemporarilyByPositionId.Middlewares;
using MediatR;

namespace FuDever.Application.Features.Position.RemovePositionTemporarilyByPositionId;

/// <summary>
///     Remove position temporarily by position id request.
/// </summary>
public sealed class RemovePositionTemporarilyByPositionIdRequest
    : IRequest<RemovePositionTemporarilyByPositionIdResponse>,
        IRemovePositionTemporarilyByPositionIdMiddleware
{
    public Guid PositionId { get; init; }
}
