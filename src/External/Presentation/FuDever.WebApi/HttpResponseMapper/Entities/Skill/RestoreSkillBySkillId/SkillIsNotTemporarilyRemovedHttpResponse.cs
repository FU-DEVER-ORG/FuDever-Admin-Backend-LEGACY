using FuDever.Application.Features.Skill.RestoreSkillBySkillId;
using FuDever.WebApi.HttpResponseMapper.Entities.Skill.RestoreSkillBySkillId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Skill.RestoreSkillBySkillId;

/// <summary>
///     Restore skill by skill
///     Id response status code - skill id not
///     found http response.
/// </summary>
internal sealed class SkillIsNotTemporarilyRemovedHttpResponse : RestoreSkillBySkillIdHttpResponse
{
    internal SkillIsNotTemporarilyRemovedHttpResponse(
        RestoreSkillBySkillIdRequest request,
        RestoreSkillBySkillIdResponse response
    )
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages =
        [
            $"Skill with Id = {request.SkillId} is not found in temporarily removed storage."
        ];
    }
}
