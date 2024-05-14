using FuDever.Application.Features.Skill.CreateSkill;
using FuDever.WebApi.HttpResponseMapper.Entities.Skill.CreateSkill.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Skill.CreateSkill;

/// <summary>
///     Create skill response status code
///     - position already exists http response.
/// </summary>
internal sealed class SkillAlreadyExistsHttpResponse : CreateSkillHttpResponse
{
    internal SkillAlreadyExistsHttpResponse(
        CreateSkillRequest request,
        CreateSkillResponse response
    )
    {
        HttpCode = StatusCodes.Status409Conflict;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"Skill with name = {request.NewSkillName} already exists."];
    }
}
