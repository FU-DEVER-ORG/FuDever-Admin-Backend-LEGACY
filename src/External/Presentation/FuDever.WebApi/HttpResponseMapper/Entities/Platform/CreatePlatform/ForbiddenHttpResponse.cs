using FuDever.Application.Features.Platform.CreatePlatform;
using FuDever.WebApi.HttpResponseMapper.Entities.Platform.CreatePlatform.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Platform.CreatePlatform;

/// <summary>
///     Create platform response status code
///     - forbidden http response.
/// </summary>
internal sealed class ForbiddenHttpResponse : CreatePlatformHttpResponse
{
    internal ForbiddenHttpResponse(CreatePlatformResponse response)
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
    }
}
