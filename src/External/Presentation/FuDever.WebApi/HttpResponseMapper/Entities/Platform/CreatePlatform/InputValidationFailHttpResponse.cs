using FuDever.Application.Features.Platform.CreatePlatform;
using FuDever.WebApi.HttpResponseMapper.Entities.Platform.CreatePlatform.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Platform.CreatePlatform;

/// <summary>
///     Create platform response status code
///     - input validation fail http response.
/// </summary>
internal sealed class InputValidationFailHttpResponse : CreatePlatformHttpResponse
{
    internal InputValidationFailHttpResponse(CreatePlatformResponse response)
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Input validation fail. Please check your inputs and try again."];
    }
}
