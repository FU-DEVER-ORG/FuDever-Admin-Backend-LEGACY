using FuDever.Application.Features.Platform.UpdatePlatformByPlatformId;
using FuDever.WebApi.HttpResponseMapper.Entities.Platform.UpdatePlatformByPlatformId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Platform.UpdatePlatformByPlatformId;

/// <summary>
///     Update platform by platform
///     Id response status code - platform is already
///     temporarily removed http response.
/// </summary>
internal sealed class PlatformIsAlreadyTemporarilyRemovedHttpResponse
    : UpdatePlatformByPlatformIdHttpResponse
{
    internal PlatformIsAlreadyTemporarilyRemovedHttpResponse(
        UpdatePlatformByPlatformIdRequest request,
        UpdatePlatformByPlatformIdResponse response
    )
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages =
        [
            $"Found platform with Id = {request.PlatformId} in temporarily removed storage."
        ];
    }
}
