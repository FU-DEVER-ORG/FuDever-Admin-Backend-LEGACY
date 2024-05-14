using FuDever.Application.Features.Platform.CreatePlatform;
using FuDever.WebApi.HttpResponseMapper.Entities.Platform.CreatePlatform.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Platform.CreatePlatform;

/// <summary>
///     Create platform response status code
///     - platform already exists http response.
/// </summary>
internal sealed class PlatformAlreadyExistsHttpResponse : CreatePlatformHttpResponse
{
    internal PlatformAlreadyExistsHttpResponse(
        CreatePlatformRequest request,
        CreatePlatformResponse response
    )
    {
        HttpCode = StatusCodes.Status409Conflict;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"Platform with name = {request.NewPlatformName} already exists."];
    }
}
