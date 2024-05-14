using FuDever.Application.Features.Skill.GetAllSkills;
using FuDever.WebApi.HttpResponseMapper.Entities.Skill.GetAllSkills.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Skill.GetAllSkills;

/// <summary>
///     Get all skills response status code
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : GetAllSkillsHttpResponse
{
    internal OperationSuccessHttpResponse(GetAllSkillsResponse response)
    {
        HttpCode = StatusCodes.Status200OK;
        AppCode = response.StatusCode.ToAppCode();
        Body = response.FoundSkills;
    }
}
