using FuDever.Application.Features.Position.RemovePositionPermanentlyByPositionId;
using FuDever.WebApi.HttpResponseMapper.Entities.Position.RemovePositionPermanentlyByPositionId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Position.RemovePositionPermanentlyByPositionId;

/// <summary>
///     Remove position permanently by position
///     Id response status code - position id not
///     found http response.
/// </summary>
internal sealed class PositionIsNotTemporarilyRemovedHttpResponse
    : RemovePositionPermanentlyByPositionIdHttpResponse
{
    internal PositionIsNotTemporarilyRemovedHttpResponse(
        RemovePositionPermanentlyByPositionIdRequest request,
        RemovePositionPermanentlyByPositionIdResponse response
    )
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages =
        [
            $"Position with Id = {request.PositionId} is not found in temporarily removed storage."
        ];
    }
}
