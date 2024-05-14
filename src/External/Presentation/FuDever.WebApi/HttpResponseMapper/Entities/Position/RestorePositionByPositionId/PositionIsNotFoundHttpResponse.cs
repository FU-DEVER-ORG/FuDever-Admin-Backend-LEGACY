using FuDever.Application.Features.Position.RestorePositionByPositionId;
using FuDever.WebApi.HttpResponseMapper.Entities.Position.RestorePositionByPositionId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Position.RestorePositionByPositionId;

/// <summary>
///     Restore position by position
///     Id response status code - position is not
///     found http response.
/// </summary>
internal sealed class PositionIsNotFoundHttpResponse : RestorePositionByPositionIdHttpResponse
{
    internal PositionIsNotFoundHttpResponse(
        RestorePositionByPositionIdRequest request,
        RestorePositionByPositionIdResponse response
    )
    {
        HttpCode = StatusCodes.Status404NotFound;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"Position with Id = {request.PositionId} is not found."];
    }
}
