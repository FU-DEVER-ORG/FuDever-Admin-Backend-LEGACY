using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using FuDever.Application.Features.Department.GetAllTemporarilyRemovedDepartments;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Department.GetAllTemporarilyRemovedDepartments.Others;

/// <summary>
///     Implementation for get all temporarily
///     removed department http response.
/// </summary>
internal class GetAllTemporarilyRemovedDepartmentsHttpResponse
{
    [JsonIgnore]
    public int HttpCode { get; init; }

    public string AppCode { get; init; } =
        GetAllTemporarilyRemovedDepartmentsResponseStatusCode.OPERATION_SUCCESS.ToAppCode();

    public DateTime ResponseTime { get; init; } =
        TimeZoneInfo.ConvertTimeFromUtc(
            dateTime: DateTime.UtcNow,
            destinationTimeZone: TimeZoneInfo.FindSystemTimeZoneById(id: "SE Asia Standard Time")
        );

    public object Body { get; init; } = new();

    public IEnumerable<string> ErrorMessages { get; init; } = [];
}
