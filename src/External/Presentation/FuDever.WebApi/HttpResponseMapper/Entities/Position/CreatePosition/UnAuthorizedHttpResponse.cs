using FuDever.Application.Features.Position.CreatePosition;
using FuDever.WebApi.HttpResponseMapper.Entities.Position.CreatePosition.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Position.CreatePosition;

/// <summary>
///     Create position response status code
///     - un authorized http response.
/// </summary>
internal sealed class UnAuthorizedHttpResponse : CreatePositionHttpResponse
{
    internal UnAuthorizedHttpResponse(CreatePositionResponse response)
    {
        HttpCode = StatusCodes.Status401Unauthorized;
        AppCode = response.StatusCode.ToAppCode();
    }
}
