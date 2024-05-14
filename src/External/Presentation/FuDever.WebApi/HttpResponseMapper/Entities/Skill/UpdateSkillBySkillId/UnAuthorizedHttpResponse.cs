using FuDever.Application.Features.Skill.UpdateSkillBySkillId;
using FuDever.WebApi.HttpResponseMapper.Entities.Skill.UpdateSkillBySkillId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Skill.UpdateSkillBySkillId;

/// <summary>
///     Update skill by skill
///     Id response status code
///     - un authorized http response.
/// </summary>
internal sealed class UnAuthorizedHttpResponse : UpdateSkillBySkillIdHttpResponse
{
    internal UnAuthorizedHttpResponse(UpdateSkillBySkillIdResponse response)
    {
        HttpCode = StatusCodes.Status401Unauthorized;
        AppCode = response.StatusCode.ToAppCode();
    }
}
