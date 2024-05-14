using FuDever.Application.Features.Hobby.GetAllHobbies;
using FuDever.WebApi.HttpResponseMapper.Entities.Hobby.GetAllHobbies.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Hobby.GetAllHobbies;

/// <summary>
///     Get all hobbies response status code
///     - input validation fail http response.
/// </summary>
internal sealed class InputValidationFailHttpResponse : GetAllHobbiesHttpResponse
{
    internal InputValidationFailHttpResponse(GetAllHobbiesResponse response)
    {
        HttpCode = StatusCodes.Status500InternalServerError;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Server error. Please try again later."];
    }
}
