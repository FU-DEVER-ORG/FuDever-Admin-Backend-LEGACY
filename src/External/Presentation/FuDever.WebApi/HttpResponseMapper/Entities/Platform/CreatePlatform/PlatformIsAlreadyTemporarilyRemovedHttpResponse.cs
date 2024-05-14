using FuDever.Application.Features.Platform.CreatePlatform;
using FuDever.WebApi.HttpResponseMapper.Entities.Platform.CreatePlatform.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Platform.CreatePlatform;

/// <summary>
///     Create platform response status code
///     - platform is already temporarily removed
///     http response.
/// </summary>
internal sealed class PlatformIsAlreadyTemporarilyRemovedHttpResponse : CreatePlatformHttpResponse
{
    internal PlatformIsAlreadyTemporarilyRemovedHttpResponse(
        CreatePlatformRequest request,
        CreatePlatformResponse response
    )
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages =
        [
            $"Found platform with name = {request.NewPlatformName} in temporarily removed storage."
        ];
    }
}
