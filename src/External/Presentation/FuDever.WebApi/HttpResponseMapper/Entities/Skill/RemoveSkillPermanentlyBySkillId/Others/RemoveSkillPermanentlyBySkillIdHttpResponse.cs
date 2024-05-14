using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using FuDever.Application.Features.Skill.RemoveSkillPermanentlyBySkillId;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Skill.RemoveSkillPermanentlyBySkillId.Others;

/// <summary>
///     Implementation for remove skill permanently
///     by skill id http response.
/// </summary>
internal class RemoveSkillPermanentlyBySkillIdHttpResponse
{
    [JsonIgnore]
    public int HttpCode { get; init; }

    public string AppCode { get; init; } =
        RemoveSkillPermanentlyBySkillIdResponseStatusCode.OPERATION_SUCCESS.ToAppCode();

    public DateTime ResponseTime { get; init; } =
        TimeZoneInfo.ConvertTimeFromUtc(
            dateTime: DateTime.UtcNow,
            destinationTimeZone: TimeZoneInfo.FindSystemTimeZoneById(id: "SE Asia Standard Time")
        );

    public object Body { get; init; } = new();

    public IEnumerable<string> ErrorMessages { get; init; } = [];
}
