using FuDever.Application.Features.Skill.GetAllTemporarilyRemovedSkills;
using FuDever.WebApi.HttpResponseMapper.Entities.Skill.GetAllTemporarilyRemovedSkills.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Skill.GetAllTemporarilyRemovedSkills;

/// <summary>
///     Get all temporarily removed skills response status code
///     - forbidden http response.
/// </summary>
internal sealed class ForbiddenHttpResponse : GetAllTemporarilyRemovedSkillsHttpResponse
{
    internal ForbiddenHttpResponse(GetAllTemporarilyRemovedSkillsResponse response)
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
    }
}
