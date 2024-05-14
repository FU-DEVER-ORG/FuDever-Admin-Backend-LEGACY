using FuDever.Application.Features.Skill.RemoveSkillPermanentlyBySkillId;
using FuDever.WebApi.HttpResponseMapper.Entities.Skill.RemoveSkillPermanentlyBySkillId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Skill.RemoveSkillPermanentlyBySkillId;

/// <summary>
///     Remove skill permanently by skill
///     Id response status code
///     - forbidden http response.
/// </summary>
internal sealed class ForbiddenHttpResponse : RemoveSkillPermanentlyBySkillIdHttpResponse
{
    internal ForbiddenHttpResponse(RemoveSkillPermanentlyBySkillIdResponse response)
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
    }
}
