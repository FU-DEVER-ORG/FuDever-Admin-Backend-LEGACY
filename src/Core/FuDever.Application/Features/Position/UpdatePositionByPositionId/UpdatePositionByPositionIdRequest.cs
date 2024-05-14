using System;
using FuDever.Application.Features.Position.UpdatePositionByPositionId.Middlewares;
using MediatR;

namespace FuDever.Application.Features.Position.UpdatePositionByPositionId;

/// <summary>
///     Update position by position id request.
/// </summary>
public sealed class UpdatePositionByPositionIdRequest
    : IRequest<UpdatePositionByPositionIdResponse>,
        IUpdatePositionByPositionIdMiddleware
{
    public Guid PositionId { get; init; }

    public string NewPositionName { get; init; }
}
