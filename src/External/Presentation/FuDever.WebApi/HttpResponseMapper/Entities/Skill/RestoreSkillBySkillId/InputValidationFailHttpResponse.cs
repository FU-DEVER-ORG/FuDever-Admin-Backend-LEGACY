using FuDever.Application.Features.Skill.RestoreSkillBySkillId;
using FuDever.WebApi.HttpResponseMapper.Entities.Skill.RestoreSkillBySkillId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Skill.RestoreSkillBySkillId;

/// <summary>
///     Restore skill by skill
///     Id response status code - input validation
///     fail http response.
/// </summary>
internal sealed class InputValidationFailHttpResponse : RestoreSkillBySkillIdHttpResponse
{
    internal InputValidationFailHttpResponse(RestoreSkillBySkillIdResponse response)
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Input validation fail. Please check your inputs and try again."];
    }
}
