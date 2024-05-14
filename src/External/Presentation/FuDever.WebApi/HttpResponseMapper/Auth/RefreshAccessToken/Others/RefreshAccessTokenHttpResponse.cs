﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using FuDever.Application.Features.Auth.RefreshAccessToken;

namespace FuDever.WebApi.HttpResponseMapper.Auth.RefreshAccessToken.Others;

/// <summary>
///     Implementation for refresh access token
///     http response.
/// </summary>
internal class RefreshAccessTokenHttpResponse
{
    [JsonIgnore]
    public int HttpCode { get; init; }

    public string AppCode { get; init; } =
        RefreshAccessTokenResponseStatusCode.OPERATION_SUCCESS.ToAppCode();

    public DateTime ResponseTime { get; init; } =
        TimeZoneInfo.ConvertTimeFromUtc(
            dateTime: DateTime.UtcNow,
            destinationTimeZone: TimeZoneInfo.FindSystemTimeZoneById(id: "SE Asia Standard Time")
        );

    public object Body { get; init; } = new();

    public IEnumerable<string> ErrorMessages { get; init; } = [];
}
