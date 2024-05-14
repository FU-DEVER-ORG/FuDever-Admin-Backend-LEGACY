using FuDever.Application.Features.Platform.RemovePlatformPermanentlyByPlatformId;
using FuDever.WebApi.HttpResponseMapper.Entities.Platform.RemovePlatformPermanentlyByPlatformId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Platform.RemovePlatformPermanentlyByPlatformId;

/// <summary>
///     Remove platform permanently by platform
///     Id response status code - operation
///     success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse
    : RemovePlatformPermanentlyByPlatformIdHttpResponse
{
    internal OperationSuccessHttpResponse(RemovePlatformPermanentlyByPlatformIdResponse response)
    {
        HttpCode = StatusCodes.Status200OK;
        AppCode = response.StatusCode.ToAppCode();
    }
}
