using FuDever.Application.Features.Skill.CreateSkill;
using FuDever.WebApi.HttpResponseMapper.Entities.Skill.CreateSkill.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Skill.CreateSkill;

/// <summary>
///     Create skill response status code
///     - database operation fail http response.
/// </summary>
internal sealed class DatabaseOperationFailHttpResponse : CreateSkillHttpResponse
{
    internal DatabaseOperationFailHttpResponse(CreateSkillResponse response)
    {
        HttpCode = StatusCodes.Status500InternalServerError;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Server error !!!"];
    }
}
