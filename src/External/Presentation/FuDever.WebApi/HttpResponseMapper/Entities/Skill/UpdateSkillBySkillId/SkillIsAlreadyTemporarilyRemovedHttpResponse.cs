using FuDever.Application.Features.Skill.UpdateSkillBySkillId;
using FuDever.WebApi.HttpResponseMapper.Entities.Skill.UpdateSkillBySkillId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Skill.UpdateSkillBySkillId;

/// <summary>
///     Update skill by skill
///     Id response status code - skill is already
///     temporarily removed http response.
/// </summary>
internal sealed class SkillIsAlreadyTemporarilyRemovedHttpResponse
    : UpdateSkillBySkillIdHttpResponse
{
    internal SkillIsAlreadyTemporarilyRemovedHttpResponse(
        UpdateSkillBySkillIdRequest request,
        UpdateSkillBySkillIdResponse response
    )
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages =
        [
            $"Found skill with Id = {request.SkillId} in temporarily removed storage."
        ];
    }
}
