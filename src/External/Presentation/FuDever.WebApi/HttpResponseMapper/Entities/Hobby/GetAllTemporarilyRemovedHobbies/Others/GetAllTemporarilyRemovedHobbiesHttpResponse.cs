using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using FuDever.Application.Features.Hobby.GetAllTemporarilyRemovedHobbies;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Hobby.GetAllTemporarilyRemovedHobbies.Others;

/// <summary>
///     Implementation for get all temporarily
///     removed hobbies http response.
/// </summary>
internal class GetAllTemporarilyRemovedHobbiesHttpResponse
{
    [JsonIgnore]
    public int HttpCode { get; init; }

    public string AppCode { get; init; } =
        GetAllTemporarilyRemovedHobbiesResponseStatusCode.OPERATION_SUCCESS.ToAppCode();

    public DateTime ResponseTime { get; init; } =
        TimeZoneInfo.ConvertTimeFromUtc(
            dateTime: DateTime.UtcNow,
            destinationTimeZone: TimeZoneInfo.FindSystemTimeZoneById(id: "SE Asia Standard Time")
        );

    public object Body { get; init; } = new();

    public IEnumerable<string> ErrorMessages { get; init; } = [];
}
