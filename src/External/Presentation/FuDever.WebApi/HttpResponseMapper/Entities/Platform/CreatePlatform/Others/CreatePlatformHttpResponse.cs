using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using FuDever.Application.Features.Platform.CreatePlatform;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Platform.CreatePlatform.Others;

/// <summary>
///     Implementation for create hobby
///     http response.
/// </summary>
internal class CreatePlatformHttpResponse
{
    [JsonIgnore]
    public int HttpCode { get; init; }

    public string AppCode { get; init; } =
        CreatePlatformResponseStatusCode.OPERATION_SUCCESS.ToAppCode();

    public DateTime ResponseTime { get; init; } =
        TimeZoneInfo.ConvertTimeFromUtc(
            dateTime: DateTime.UtcNow,
            destinationTimeZone: TimeZoneInfo.FindSystemTimeZoneById(id: "SE Asia Standard Time")
        );

    public object Body { get; init; } = new();

    public IEnumerable<string> ErrorMessages { get; init; } = [];
}
