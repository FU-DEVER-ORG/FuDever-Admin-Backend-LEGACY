using FuDever.Application.Features.Platform.RemovePlatformPermanentlyByPlatformId;
using FuDever.WebApi.HttpResponseMapper.Entities.Platform.RemovePlatformPermanentlyByPlatformId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Platform.RemovePlatformPermanentlyByPlatformId;

/// <summary>
///     Remove platform permanently by platform
///     Id response status code - platform id not
///     found http response.
/// </summary>
internal sealed class PlatformIsNotTemporarilyRemovedHttpResponse
    : RemovePlatformPermanentlyByPlatformIdHttpResponse
{
    internal PlatformIsNotTemporarilyRemovedHttpResponse(
        RemovePlatformPermanentlyByPlatformIdRequest request,
        RemovePlatformPermanentlyByPlatformIdResponse response
    )
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages =
        [
            $"Platform with Id = {request.PlatformId} is not found in temporarily removed storage."
        ];
    }
}
