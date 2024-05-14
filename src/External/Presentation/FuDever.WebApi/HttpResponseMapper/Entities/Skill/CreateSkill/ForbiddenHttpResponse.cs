using FuDever.Application.Features.Skill.CreateSkill;
using FuDever.WebApi.HttpResponseMapper.Entities.Skill.CreateSkill.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Skill.CreateSkill;

/// <summary>
///     Create skill response status code
///     - forbidden http response.
/// </summary>
internal sealed class ForbiddenHttpResponse : CreateSkillHttpResponse
{
    internal ForbiddenHttpResponse(CreateSkillResponse response)
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
    }
}
