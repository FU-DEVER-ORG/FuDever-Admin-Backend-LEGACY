using FuDever.Application.Features.Position.UpdatePositionByPositionId;
using FuDever.WebApi.HttpResponseMapper.Entities.Position.UpdatePositionByPositionId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Position.UpdatePositionByPositionId;

/// <summary>
///     Update position by position id response
///     status code - position already exists
///     http response.
/// </summary>
internal sealed class PositionAlreadyExistsHttpResponse : UpdatePositionByPositionIdHttpResponse
{
    internal PositionAlreadyExistsHttpResponse(
        UpdatePositionByPositionIdRequest request,
        UpdatePositionByPositionIdResponse response
    )
    {
        HttpCode = StatusCodes.Status409Conflict;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"Position with name = {request.NewPositionName} already exists."];
    }
}
