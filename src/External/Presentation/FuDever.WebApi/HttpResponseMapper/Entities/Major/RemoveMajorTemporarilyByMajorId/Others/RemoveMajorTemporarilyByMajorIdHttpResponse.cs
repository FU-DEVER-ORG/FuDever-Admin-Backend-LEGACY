using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using FuDever.Application.Features.Major.RemoveMajorTemporarilyByMajorId;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Major.RemoveMajorTemporarilyByMajorId.Others;

/// <summary>
///     Implementation for remove major
///     temporarily by major id http
///     response.
/// </summary>
internal class RemoveMajorTemporarilyByMajorIdHttpResponse
{
    [JsonIgnore]
    public int HttpCode { get; init; }

    public string AppCode { get; init; } =
        RemoveMajorTemporarilyByMajorIdResponseStatusCode.OPERATION_SUCCESS.ToAppCode();

    public DateTime ResponseTime { get; init; } =
        TimeZoneInfo.ConvertTimeFromUtc(
            dateTime: DateTime.UtcNow,
            destinationTimeZone: TimeZoneInfo.FindSystemTimeZoneById(id: "SE Asia Standard Time")
        );

    public object Body { get; init; } = new();

    public IEnumerable<string> ErrorMessages { get; init; } = [];
}
