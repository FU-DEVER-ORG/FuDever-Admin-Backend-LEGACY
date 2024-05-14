using FuDever.Application.Features.Position.GetAllTemporarilyRemovedPositions;
using FuDever.WebApi.HttpResponseMapper.Entities.Position.GetAllTemporarilyRemovedPositions.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Position.GetAllTemporarilyRemovedPositions;

/// <summary>
///    Get all temporarily removed positions response status code
///     - un authorized http response.
/// </summary>
internal sealed class UnAuthorizedHttpResponse : GetAllTemporarilyRemovedPositionsHttpResponse
{
    internal UnAuthorizedHttpResponse(GetAllTemporarilyRemovedPositionsResponse response)
    {
        HttpCode = StatusCodes.Status401Unauthorized;
        AppCode = response.StatusCode.ToAppCode();
    }
}
