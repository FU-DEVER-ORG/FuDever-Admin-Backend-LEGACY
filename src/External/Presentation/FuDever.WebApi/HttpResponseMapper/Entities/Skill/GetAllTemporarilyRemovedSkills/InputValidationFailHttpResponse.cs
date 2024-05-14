using FuDever.Application.Features.Skill.GetAllTemporarilyRemovedSkills;
using FuDever.WebApi.HttpResponseMapper.Entities.Skill.GetAllTemporarilyRemovedSkills.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Skill.GetAllTemporarilyRemovedSkills;

/// <summary>
///     Get all temporarily removed skills response status code
///     - input validation fail http response.
/// </summary>
internal sealed class InputValidationFailHttpResponse : GetAllTemporarilyRemovedSkillsHttpResponse
{
    internal InputValidationFailHttpResponse(GetAllTemporarilyRemovedSkillsResponse response)
    {
        HttpCode = StatusCodes.Status500InternalServerError;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Server error. Please try again later."];
    }
}
