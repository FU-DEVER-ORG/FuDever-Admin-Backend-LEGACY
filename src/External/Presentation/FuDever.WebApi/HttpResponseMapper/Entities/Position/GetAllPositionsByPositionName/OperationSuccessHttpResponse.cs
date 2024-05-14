using FuDever.Application.Features.Position.GetAllPositionsByPositionName;
using FuDever.WebApi.HttpResponseMapper.Entities.Position.GetAllPositionsByPositionName.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Position.GetAllPositionsByPositionName;

/// <summary>
///     Get all positions by position name response status code
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : GetAllPositionsByPositionNameHttpResponse
{
    internal OperationSuccessHttpResponse(GetAllPositionsByPositionNameResponse response)
    {
        HttpCode = StatusCodes.Status200OK;
        AppCode = response.StatusCode.ToAppCode();
        Body = response.FoundPositions;
    }
}
