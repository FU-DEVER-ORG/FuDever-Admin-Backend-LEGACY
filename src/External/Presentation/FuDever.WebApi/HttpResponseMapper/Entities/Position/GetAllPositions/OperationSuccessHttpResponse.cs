using FuDever.Application.Features.Position.GetAllPositions;
using FuDever.WebApi.HttpResponseMapper.Entities.Position.GetAllPositions.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Position.GetAllPositions;

/// <summary>
///     Get all positions response status code
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : GetAllPositionsHttpResponse
{
    internal OperationSuccessHttpResponse(GetAllPositionsResponse response)
    {
        HttpCode = StatusCodes.Status200OK;
        AppCode = response.StatusCode.ToAppCode();
        Body = response.FoundPositions;
    }
}
