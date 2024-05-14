using FuDever.Application.Features.Skill.UpdateSkillBySkillId;
using FuDever.WebApi.HttpResponseMapper.Entities.Skill.UpdateSkillBySkillId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Skill.UpdateSkillBySkillId;

/// <summary>
///     Update skill by skill
///     Id response status code - skill is not
///     found http response.
/// </summary>
internal sealed class SkillIsNotFoundHttpResponse : UpdateSkillBySkillIdHttpResponse
{
    internal SkillIsNotFoundHttpResponse(
        UpdateSkillBySkillIdRequest request,
        UpdateSkillBySkillIdResponse response
    )
    {
        HttpCode = StatusCodes.Status404NotFound;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"Skill with Id = {request.SkillId} is not found."];
    }
}
