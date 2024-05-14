﻿using System;
using FuDever.Application.Features.Major.RestoreMajorByMajorId.Middlewares;
using MediatR;

namespace FuDever.Application.Features.Major.RestoreMajorByMajorId;

/// <summary>
///     Restore major by major id request.
/// </summary>
public sealed class RestoreMajorByMajorIdRequest
    : IRequest<RestoreMajorByMajorIdResponse>,
        IRestoreMajorByMajorIdMiddleware
{
    public Guid MajorId { get; init; }
}
