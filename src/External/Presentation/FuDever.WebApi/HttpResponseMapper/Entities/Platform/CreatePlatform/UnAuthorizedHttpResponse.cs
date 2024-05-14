using FuDever.Application.Features.Platform.CreatePlatform;
using FuDever.WebApi.HttpResponseMapper.Entities.Platform.CreatePlatform.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Platform.CreatePlatform;

/// <summary>
///     Create platform response status code
///     - un authorized http response.
/// </summary>
internal sealed class UnAuthorizedHttpResponse : CreatePlatformHttpResponse
{
    internal UnAuthorizedHttpResponse(CreatePlatformResponse response)
    {
        HttpCode = StatusCodes.Status401Unauthorized;
        AppCode = response.StatusCode.ToAppCode();
    }
}
