﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using FuDever.Application.Features.Position.RemovePositionTemporarilyByPositionId;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Position.RemovePositionTemporarilyByPositionId.Others;

/// <summary>
///     Implementation for remove position
///     temporarily by position id http
///     response.
/// </summary>
internal class RemovePositionTemporarilyByPositionIdHttpResponse
{
    [JsonIgnore]
    public int HttpCode { get; init; }

    public string AppCode { get; init; } =
        RemovePositionTemporarilyByPositionIdResponseStatusCode.OPERATION_SUCCESS.ToAppCode();

    public DateTime ResponseTime { get; init; } =
        TimeZoneInfo.ConvertTimeFromUtc(
            dateTime: DateTime.UtcNow,
            destinationTimeZone: TimeZoneInfo.FindSystemTimeZoneById(id: "SE Asia Standard Time")
        );

    public object Body { get; init; } = new();

    public IEnumerable<string> ErrorMessages { get; init; } = [];
}
