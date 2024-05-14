using FuDever.Application.Features.Skill.RemoveSkillTemporarilyBySkillId;
using FuDever.WebApi.HttpResponseMapper.Entities.Skill.RemoveSkillTemporarilyBySkillId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Skill.RemoveSkillTemporarilyBySkillId;

/// <summary>
///     Remove skill temporarily by skill
///     Id response status code - operation success
///     http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : RemoveSkillTemporarilyBySkillIdHttpResponse
{
    internal OperationSuccessHttpResponse(RemoveSkillTemporarilyBySkillIdResponse response)
    {
        HttpCode = StatusCodes.Status200OK;
        AppCode = response.StatusCode.ToAppCode();
    }
}
