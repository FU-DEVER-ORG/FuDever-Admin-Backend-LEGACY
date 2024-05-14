using FuDever.Application.Features.Position.RemovePositionTemporarilyByPositionId;
using FuDever.WebApi.HttpResponseMapper.Entities.Position.RemovePositionTemporarilyByPositionId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Position.RemovePositionTemporarilyByPositionId;

/// <summary>
///    Remove position temporarily by
///    position response status code
///     - un authorized http response.
/// </summary>
internal sealed class UnAuthorizedHttpResponse : RemovePositionTemporarilyByPositionIdHttpResponse
{
    internal UnAuthorizedHttpResponse(RemovePositionTemporarilyByPositionIdResponse response)
    {
        HttpCode = StatusCodes.Status401Unauthorized;
        AppCode = response.StatusCode.ToAppCode();
    }
}
