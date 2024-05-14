using FuDever.Application.Features.Position.RemovePositionTemporarilyByPositionId;
using FuDever.WebApi.HttpResponseMapper.Entities.Position.RemovePositionTemporarilyByPositionId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Position.RemovePositionTemporarilyByPositionId;

/// <summary>
///     Remove position temporarily by position
///     Id response status code - position is already
///     temporarily removed http response.
/// </summary>
internal sealed class PositionIsAlreadyTemporarilyRemovedHttpResponse
    : RemovePositionTemporarilyByPositionIdHttpResponse
{
    internal PositionIsAlreadyTemporarilyRemovedHttpResponse(
        RemovePositionTemporarilyByPositionIdRequest request,
        RemovePositionTemporarilyByPositionIdResponse response
    )
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages =
        [
            $"Found position with Id = {request.PositionId} in temporarily removed storage."
        ];
    }
}
