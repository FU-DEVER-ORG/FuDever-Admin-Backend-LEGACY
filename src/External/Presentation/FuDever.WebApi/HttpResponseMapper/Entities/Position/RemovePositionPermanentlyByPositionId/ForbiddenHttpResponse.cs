using FuDever.Application.Features.Position.RemovePositionPermanentlyByPositionId;
using FuDever.WebApi.HttpResponseMapper.Entities.Position.RemovePositionPermanentlyByPositionId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Position.RemovePositionPermanentlyByPositionId;

/// <summary>
///     Remove position permanently by
///     position response status code
///     - forbidden http response.
/// </summary>
internal sealed class ForbiddenHttpResponse : RemovePositionPermanentlyByPositionIdHttpResponse
{
    internal ForbiddenHttpResponse(RemovePositionPermanentlyByPositionIdResponse response)
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
    }
}
