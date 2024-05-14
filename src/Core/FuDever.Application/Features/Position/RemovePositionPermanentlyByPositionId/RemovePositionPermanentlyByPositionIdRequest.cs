using System;
using FuDever.Application.Features.Department.RemoveDepartmentPermanentlyByDepartmentId.Middlewares;
using MediatR;

namespace FuDever.Application.Features.Position.RemovePositionPermanentlyByPositionId;

/// <summary>
///     Remove position permanently by position id request.
/// </summary>
public sealed class RemovePositionPermanentlyByPositionIdRequest
    : IRequest<RemovePositionPermanentlyByPositionIdResponse>,
        IRemoveDepartmentPermanentlyByDepartmentIdMiddleware
{
    public Guid PositionId { get; init; }
}
