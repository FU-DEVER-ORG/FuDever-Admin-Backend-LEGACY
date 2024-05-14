using FuDever.Application.Features.Platform.RemovePlatformTemporarilyByPlatformId;
using FuDever.WebApi.HttpResponseMapper.Entities.Platform.RemovePlatformTemporarilyByPlatformId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Platform.RemovePlatformTemporarilyByPlatformId;

/// <summary>
///     Remove platform temporarily by platform
///     Id response status code - database operation
///     fail http response.
/// </summary>
internal sealed class DatabaseOperationFailHttpResponse
    : RemovePlatformTemporarilyByPlatformIdHttpResponse
{
    internal DatabaseOperationFailHttpResponse(
        RemovePlatformTemporarilyByPlatformIdResponse response
    )
    {
        HttpCode = StatusCodes.Status500InternalServerError;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Server error !!!"];
    }
}
