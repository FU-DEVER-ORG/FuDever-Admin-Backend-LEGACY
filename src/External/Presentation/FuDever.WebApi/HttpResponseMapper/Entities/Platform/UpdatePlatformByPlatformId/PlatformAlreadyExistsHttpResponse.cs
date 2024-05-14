using FuDever.Application.Features.Platform.UpdatePlatformByPlatformId;
using FuDever.WebApi.HttpResponseMapper.Entities.Platform.UpdatePlatformByPlatformId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Platform.UpdatePlatformByPlatformId;

/// <summary>
///     Update platform by platform id response
///     status code - platform already exists
///     http response.
/// </summary>
internal sealed class PlatformAlreadyExistsHttpResponse : UpdatePlatformByPlatformIdHttpResponse
{
    internal PlatformAlreadyExistsHttpResponse(
        UpdatePlatformByPlatformIdRequest request,
        UpdatePlatformByPlatformIdResponse response
    )
    {
        HttpCode = StatusCodes.Status409Conflict;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"Platform with name = {request.NewPlatformName} already exists."];
    }
}
