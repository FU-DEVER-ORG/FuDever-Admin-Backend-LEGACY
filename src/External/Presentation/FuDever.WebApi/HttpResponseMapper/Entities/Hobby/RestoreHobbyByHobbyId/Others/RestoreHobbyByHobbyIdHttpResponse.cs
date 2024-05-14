using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using FuDever.Application.Features.Hobby.RestoreHobbyByHobbyId;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Hobby.RestoreHobbyByHobbyId.Others;

/// <summary>
///     Implementation for restore hobby
///     by hobby id http response.
/// </summary>
internal class RestoreHobbyByHobbyIdHttpResponse
{
    [JsonIgnore]
    public int HttpCode { get; init; }

    public string AppCode { get; init; } =
        RestoreHobbyByHobbyIdResponseStatusCode.OPERATION_SUCCESS.ToAppCode();

    public DateTime ResponseTime { get; init; } =
        TimeZoneInfo.ConvertTimeFromUtc(
            dateTime: DateTime.UtcNow,
            destinationTimeZone: TimeZoneInfo.FindSystemTimeZoneById(id: "SE Asia Standard Time")
        );

    public object Body { get; init; } = new();

    public IEnumerable<string> ErrorMessages { get; init; } = [];
}
