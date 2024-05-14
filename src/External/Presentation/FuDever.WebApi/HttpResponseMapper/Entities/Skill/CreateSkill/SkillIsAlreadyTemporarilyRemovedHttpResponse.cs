using FuDever.Application.Features.Skill.CreateSkill;
using FuDever.WebApi.HttpResponseMapper.Entities.Skill.CreateSkill.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Skill.CreateSkill;

/// <summary>
///     Create skill response status code
///     - skill is already temporarily removed
///     http response.
/// </summary>
internal sealed class SkillIsAlreadyTemporarilyRemovedHttpResponse : CreateSkillHttpResponse
{
    internal SkillIsAlreadyTemporarilyRemovedHttpResponse(
        CreateSkillRequest request,
        CreateSkillResponse response
    )
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages =
        [
            $"Found skill with name = {request.NewSkillName} in temporarily removed storage."
        ];
    }
}
