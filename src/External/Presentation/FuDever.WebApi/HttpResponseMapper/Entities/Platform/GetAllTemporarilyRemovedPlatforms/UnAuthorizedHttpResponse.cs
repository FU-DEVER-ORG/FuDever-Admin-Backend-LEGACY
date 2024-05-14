using FuDever.Application.Features.Platform.GetAllTemporarilyRemovedPlatforms;
using FuDever.WebApi.HttpResponseMapper.Entities.Platform.GetAllTemporarilyRemovedPlatforms.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Platform.GetAllTemporarilyRemovedPlatforms;

/// <summary>
///     Get all temporarily removed platforms response status code
///     - un authorized http response.
/// </summary>
internal sealed class UnAuthorizedHttpResponse : GetAllTemporarilyRemovedPlatformsHttpResponse
{
    internal UnAuthorizedHttpResponse(GetAllTemporarilyRemovedPlatformsResponse response)
    {
        HttpCode = StatusCodes.Status401Unauthorized;
        AppCode = response.StatusCode.ToAppCode();
    }
}
