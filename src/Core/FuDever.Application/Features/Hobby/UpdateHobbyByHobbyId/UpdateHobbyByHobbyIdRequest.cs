﻿using System;
using FuDever.Application.Features.Hobby.UpdateHobbyByHobbyId.Middlewares;
using MediatR;

namespace FuDever.Application.Features.Hobby.UpdateHobbyByHobbyId;

/// <summary>
///     Update hobby by hobby id request.
/// </summary>
public sealed class UpdateHobbyByHobbyIdRequest
    : IRequest<UpdateHobbyByHobbyIdResponse>,
        IUpdateHobbyByHobbyIdMiddleware
{
    public Guid HobbyId { get; init; }

    public string NewHobbyName { get; init; }
}
