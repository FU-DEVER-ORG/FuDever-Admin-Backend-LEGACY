using FuDever.Application.Features.Skill.GetAllSkills;
using FuDever.WebApi.HttpResponseMapper.Entities.Skill.GetAllSkills.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Skill.GetAllSkills;

/// <summary>
///     Get all skills response status code
///     - input validation fail http response.
/// </summary>
internal sealed class InputValidationFailHttpResponse : GetAllSkillsHttpResponse
{
    internal InputValidationFailHttpResponse(GetAllSkillsResponse response)
    {
        HttpCode = StatusCodes.Status500InternalServerError;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Server error. Please try again later."];
    }
}
