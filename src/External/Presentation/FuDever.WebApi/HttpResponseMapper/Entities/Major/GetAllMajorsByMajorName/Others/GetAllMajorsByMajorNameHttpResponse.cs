using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using FuDever.Application.Features.Major.GetAllMajorsByMajorName;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Major.GetAllMajorsByMajorName.Others;

/// <summary>
///     Implementation for get all majors by
///     major name http response.
/// </summary>
internal class GetAllMajorsByMajorNameHttpResponse
{
    [JsonIgnore]
    public int HttpCode { get; init; }

    public string AppCode { get; init; } =
        GetAllMajorsByMajorNameResponseStatusCode.OPERATION_SUCCESS.ToAppCode();

    public DateTime ResponseTime { get; init; } =
        TimeZoneInfo.ConvertTimeFromUtc(
            dateTime: DateTime.UtcNow,
            destinationTimeZone: TimeZoneInfo.FindSystemTimeZoneById(id: "SE Asia Standard Time")
        );

    public object Body { get; init; } = new();

    public IEnumerable<string> ErrorMessages { get; init; } = [];
}
