using FuDever.Application.Features.Position.UpdatePositionByPositionId;
using FuDever.WebApi.HttpResponseMapper.Entities.Position.UpdatePositionByPositionId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Position.UpdatePositionByPositionId;

/// <summary>
///     Update position by position
///     Id response status code - position is already
///     temporarily removed http response.
/// </summary>
internal sealed class PositionIsAlreadyTemporarilyRemovedHttpResponse
    : UpdatePositionByPositionIdHttpResponse
{
    internal PositionIsAlreadyTemporarilyRemovedHttpResponse(
        UpdatePositionByPositionIdRequest request,
        UpdatePositionByPositionIdResponse response
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
