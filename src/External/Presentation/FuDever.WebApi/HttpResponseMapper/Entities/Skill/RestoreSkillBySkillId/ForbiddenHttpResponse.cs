using FuDever.Application.Features.Skill.RestoreSkillBySkillId;
using FuDever.WebApi.HttpResponseMapper.Entities.Skill.RestoreSkillBySkillId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Skill.RestoreSkillBySkillId;

/// <summary>
///     Restore skill by skill
///     Id response status code
///     - forbidden http response.
/// </summary>
internal sealed class ForbiddenHttpResponse : RestoreSkillBySkillIdHttpResponse
{
    internal ForbiddenHttpResponse(RestoreSkillBySkillIdResponse response)
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
    }
}
