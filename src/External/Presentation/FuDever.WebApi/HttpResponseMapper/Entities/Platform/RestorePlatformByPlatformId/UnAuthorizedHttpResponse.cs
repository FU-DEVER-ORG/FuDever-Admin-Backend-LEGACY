using FuDever.Application.Features.Platform.RestorePlatformByPlatformId;
using FuDever.WebApi.HttpResponseMapper.Entities.Platform.RestorePlatformByPlatformId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Platform.RestorePlatformByPlatformId;

/// <summary>
///     Restore platform by platform
///     Id response status code
///     - un authorized http response.
/// </summary>
internal sealed class UnAuthorizedHttpResponse : RestorePlatformByPlatformIdHttpResponse
{
    internal UnAuthorizedHttpResponse(RestorePlatformByPlatformIdResponse response)
    {
        HttpCode = StatusCodes.Status401Unauthorized;
        AppCode = response.StatusCode.ToAppCode();
    }
}
