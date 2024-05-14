using FuDever.Application.Features.Skill.GetAllTemporarilyRemovedSkills;
using FuDever.WebApi.HttpResponseMapper.Entities.Skill.GetAllTemporarilyRemovedSkills.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Skill.GetAllTemporarilyRemovedSkills;

/// <summary>
///     Get all temporarily removed skills response status code
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : GetAllTemporarilyRemovedSkillsHttpResponse
{
    internal OperationSuccessHttpResponse(GetAllTemporarilyRemovedSkillsResponse response)
    {
        HttpCode = StatusCodes.Status200OK;
        AppCode = response.StatusCode.ToAppCode();
        Body = response.FoundTemporarilyRemovedSkills;
    }
}
