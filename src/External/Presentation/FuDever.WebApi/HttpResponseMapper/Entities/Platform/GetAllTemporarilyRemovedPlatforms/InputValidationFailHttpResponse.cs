using FuDever.Application.Features.Platform.GetAllTemporarilyRemovedPlatforms;
using FuDever.WebApi.HttpResponseMapper.Entities.Platform.GetAllTemporarilyRemovedPlatforms.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Platform.GetAllTemporarilyRemovedPlatforms;

/// <summary>
///     Get all temporarily removed platforms response status code
///     - input validation fail http response.
/// </summary>
internal sealed class InputValidationFailHttpResponse
    : GetAllTemporarilyRemovedPlatformsHttpResponse
{
    internal InputValidationFailHttpResponse(GetAllTemporarilyRemovedPlatformsResponse response)
    {
        HttpCode = StatusCodes.Status500InternalServerError;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Server error. Please try again later."];
    }
}
