using FuDever.Application.Features.Platform.GetAllTemporarilyRemovedPlatforms;
using FuDever.WebApi.HttpResponseMapper.Entities.Platform.GetAllTemporarilyRemovedPlatforms.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Platform.GetAllTemporarilyRemovedPlatforms;

/// <summary>
///     Get all temporarily removed platforms response status code
///     - forbidden http response.
/// </summary>
internal sealed class ForbiddenHttpResponse : GetAllTemporarilyRemovedPlatformsHttpResponse
{
    internal ForbiddenHttpResponse(GetAllTemporarilyRemovedPlatformsResponse response)
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
    }
}
