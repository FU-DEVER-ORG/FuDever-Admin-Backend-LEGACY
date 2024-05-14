using FuDever.Application.Features.Skill.GetAllSkillsBySkillName;
using FuDever.WebApi.HttpResponseMapper.Entities.Skill.GetAllSkillsBySkillName.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Skill.GetAllSkillsBySkillName;

/// <summary>
///     Get all skills by skill name response status code
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : GetAllSkillsBySkillNameHttpResponse
{
    internal OperationSuccessHttpResponse(GetAllSkillsBySkillNameResponse response)
    {
        HttpCode = StatusCodes.Status200OK;
        AppCode = response.StatusCode.ToAppCode();
        Body = response.FoundSkills;
    }
}
