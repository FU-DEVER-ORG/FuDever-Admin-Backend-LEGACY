using FuDever.Application.Features.Platform.GetAllPlatforms;
using FuDever.WebApi.HttpResponseMapper.Entities.Platform.GetAllPlatforms.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Platform.GetAllPlatforms;

/// <summary>
///     Get all platforms response status code
///     - input validation fail http response.
/// </summary>
internal sealed class InputValidationFailHttpResponse : GetAllPlatformsHttpResponse
{
    internal InputValidationFailHttpResponse(GetAllPlatformsResponse response)
    {
        HttpCode = StatusCodes.Status500InternalServerError;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Server error. Please try again later."];
    }
}
