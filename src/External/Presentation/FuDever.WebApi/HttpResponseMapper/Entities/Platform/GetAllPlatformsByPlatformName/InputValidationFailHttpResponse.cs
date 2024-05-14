using FuDever.Application.Features.Platform.GetAllPlatformsByPlatformName;
using FuDever.WebApi.HttpResponseMapper.Entities.Platform.GetAllPlatformsByPlatformName.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Platform.GetAllPlatformsByPlatformName;

/// <summary>
///     Get all platforms by platform name response status code
///     - input validation fail http response.
/// </summary>
internal sealed class InputValidationFailHttpResponse : GetAllPlatformsByPlatformNameHttpResponse
{
    internal InputValidationFailHttpResponse(GetAllPlatformsByPlatformNameResponse response)
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Input validation fail. Please check your inputs and try again."];
    }
}
