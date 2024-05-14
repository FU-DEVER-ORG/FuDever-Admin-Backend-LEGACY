using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using FuDever.Application.Features.Position.GetAllPositionsByPositionName;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Position.GetAllPositionsByPositionName.Others;

/// <summary>
///     Implementation for get all positions by
///     position name http response.
/// </summary>
internal class GetAllPositionsByPositionNameHttpResponse
{
    [JsonIgnore]
    public int HttpCode { get; init; }

    public string AppCode { get; init; } =
        GetAllPositionsByPositionNameResponseStatusCode.OPERATION_SUCCESS.ToAppCode();

    public DateTime ResponseTime { get; init; } =
        TimeZoneInfo.ConvertTimeFromUtc(
            dateTime: DateTime.UtcNow,
            destinationTimeZone: TimeZoneInfo.FindSystemTimeZoneById(id: "SE Asia Standard Time")
        );

    public object Body { get; init; } = new();

    public IEnumerable<string> ErrorMessages { get; init; } = [];
}
