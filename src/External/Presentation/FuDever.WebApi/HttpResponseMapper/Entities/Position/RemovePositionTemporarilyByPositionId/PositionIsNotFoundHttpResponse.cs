using FuDever.Application.Features.Position.RemovePositionTemporarilyByPositionId;
using FuDever.WebApi.HttpResponseMapper.Entities.Position.RemovePositionTemporarilyByPositionId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Position.RemovePositionTemporarilyByPositionId;

/// <summary>
///     Remove position temporarily by position
///     Id response status code - position is not
///     found http response.
/// </summary>
internal sealed class PositionIsNotFoundHttpResponse
    : RemovePositionTemporarilyByPositionIdHttpResponse
{
    internal PositionIsNotFoundHttpResponse(
        RemovePositionTemporarilyByPositionIdRequest request,
        RemovePositionTemporarilyByPositionIdResponse response
    )
    {
        HttpCode = StatusCodes.Status404NotFound;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"Position with Id = {request.PositionId} is not found."];
    }
}
