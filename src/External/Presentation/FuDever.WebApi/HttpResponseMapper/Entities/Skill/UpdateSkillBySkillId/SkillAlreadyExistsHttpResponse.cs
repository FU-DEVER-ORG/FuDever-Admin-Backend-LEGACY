using FuDever.Application.Features.Skill.UpdateSkillBySkillId;
using FuDever.WebApi.HttpResponseMapper.Entities.Skill.UpdateSkillBySkillId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Skill.UpdateSkillBySkillId;

/// <summary>
///     Update skill by skill id response
///     status code - skill already exists
///     http response.
/// </summary>
internal sealed class SkillAlreadyExistsHttpResponse : UpdateSkillBySkillIdHttpResponse
{
    internal SkillAlreadyExistsHttpResponse(
        UpdateSkillBySkillIdRequest request,
        UpdateSkillBySkillIdResponse response
    )
    {
        HttpCode = StatusCodes.Status409Conflict;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"Skill with name = {request.NewSkillName} already exists."];
    }
}
