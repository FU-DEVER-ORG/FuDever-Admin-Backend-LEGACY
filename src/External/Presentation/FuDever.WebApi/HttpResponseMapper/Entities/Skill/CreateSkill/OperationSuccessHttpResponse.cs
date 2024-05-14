using FuDever.Application.Features.Skill.CreateSkill;
using FuDever.WebApi.HttpResponseMapper.Entities.Skill.CreateSkill.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Skill.CreateSkill;

/// <summary>
///     Create skill response status code
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : CreateSkillHttpResponse
{
    internal OperationSuccessHttpResponse(CreateSkillResponse response)
    {
        HttpCode = StatusCodes.Status201Created;
        AppCode = response.StatusCode.ToAppCode();
    }
}
