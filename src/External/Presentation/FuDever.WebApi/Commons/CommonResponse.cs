using System;
using System.Collections.Generic;
using FuDever.WebApi.AppCodes;

namespace FuDever.WebApi.Commons;

/// <summary>
///     Contain common response for all api.
/// </summary>
/// <remarks>
///     All http responses format must be this format.
/// </remarks>
internal sealed class CommonResponse
{
    public object Body { get; init; } = new();

    public DateTime ResponseTime { get; init; } =
        TimeZoneInfo.ConvertTimeFromUtc(
            dateTime: DateTime.UtcNow,
            destinationTimeZone: TimeZoneInfo.FindSystemTimeZoneById(id: "SE Asia Standard Time")
        );

    public int AppCode { get; init; } = (int)OtherAppCode.SUCCESS;

    public IEnumerable<string> ErrorMessages { get; init; } = [];
}
