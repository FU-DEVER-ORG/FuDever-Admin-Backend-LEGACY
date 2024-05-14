using FuDever.Application.Features.Position.CreatePosition;
using FuDever.WebApi.HttpResponseMapper.Entities.Position.CreatePosition.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Position.CreatePosition;

/// <summary>
///     Create position response status code
///     - forbidden http response.
/// </summary>
internal sealed class ForbiddenHttpResponse : CreatePositionHttpResponse
{
    internal ForbiddenHttpResponse(CreatePositionResponse response)
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
    }
}
