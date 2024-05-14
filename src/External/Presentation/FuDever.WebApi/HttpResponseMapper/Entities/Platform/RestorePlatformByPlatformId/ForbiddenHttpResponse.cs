using FuDever.Application.Features.Platform.RestorePlatformByPlatformId;
using FuDever.WebApi.HttpResponseMapper.Entities.Platform.RestorePlatformByPlatformId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Platform.RestorePlatformByPlatformId;

/// <summary>
///     Restore platform by platform
///     Id response status code
///     - forbidden http response.
/// </summary>
internal sealed class ForbiddenHttpResponse : RestorePlatformByPlatformIdHttpResponse
{
    internal ForbiddenHttpResponse(RestorePlatformByPlatformIdResponse response)
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
    }
}
