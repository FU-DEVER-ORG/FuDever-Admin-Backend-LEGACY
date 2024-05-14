using FuDever.Application.Features.Skill.CreateSkill;
using FuDever.WebApi.HttpResponseMapper.Entities.Skill.CreateSkill.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Skill.CreateSkill;

/// <summary>
///     Create skill response status code
///     - un authorized http response.
/// </summary>
internal sealed class UnAuthorizedHttpResponse : CreateSkillHttpResponse
{
    internal UnAuthorizedHttpResponse(CreateSkillResponse response)
    {
        HttpCode = StatusCodes.Status401Unauthorized;
        AppCode = response.StatusCode.ToAppCode();
    }
}
