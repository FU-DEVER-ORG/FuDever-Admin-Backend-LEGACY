using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using FuDever.Application.Features.Major.GetAllTemporarilyRemovedMajors;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Major.GetAllTemporarilyRemovedMajors.Others;

/// <summary>
///     Implementation for get all temporarily
///     removed majors http response.
/// </summary>
internal class GetAllTemporarilyRemovedMajorsHttpResponse
{
    [JsonIgnore]
    public int HttpCode { get; init; }

    public string AppCode { get; init; } =
        GetAllTemporarilyRemovedMajorsResponseStatusCode.OPERATION_SUCCESS.ToAppCode();

    public DateTime ResponseTime { get; init; } =
        TimeZoneInfo.ConvertTimeFromUtc(
            dateTime: DateTime.UtcNow,
            destinationTimeZone: TimeZoneInfo.FindSystemTimeZoneById(id: "SE Asia Standard Time")
        );

    public object Body { get; init; } = new();

    public IEnumerable<string> ErrorMessages { get; init; } = [];
}
