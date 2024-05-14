using FuDever.Application.Features.Skill.RemoveSkillPermanentlyBySkillId;
using FuDever.WebApi.HttpResponseMapper.Entities.Skill.RemoveSkillPermanentlyBySkillId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Skill.RemoveSkillPermanentlyBySkillId;

/// <summary>
///     Get all temporarily removed skills response status code
///     - un authorized http response.
/// </summary>
internal sealed class UnAuthorizedHttpResponse : RemoveSkillPermanentlyBySkillIdHttpResponse
{
    internal UnAuthorizedHttpResponse(RemoveSkillPermanentlyBySkillIdResponse response)
    {
        HttpCode = StatusCodes.Status401Unauthorized;
        AppCode = response.StatusCode.ToAppCode();
    }
}
