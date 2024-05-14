using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using FuDever.Application.Features.User.GetAllUsers;

namespace FuDever.WebApi.HttpResponseMapper.Entities.User.GetAllUsers.Others;

/// <summary>
///     Implementation for get all users
///     http response.
/// </summary>
internal class GetAllUsersHttpResponse
{
    [JsonIgnore]
    public int HttpCode { get; init; }

    public string AppCode { get; init; } =
        GetAllUsersResponseStatusCode.OPERATION_SUCCESS.ToAppCode();

    public DateTime ResponseTime { get; init; } =
        TimeZoneInfo.ConvertTimeFromUtc(
            dateTime: DateTime.UtcNow,
            destinationTimeZone: TimeZoneInfo.FindSystemTimeZoneById(id: "SE Asia Standard Time")
        );

    public object Body { get; init; } = new();

    public IEnumerable<string> ErrorMessages { get; init; } = [];
}
