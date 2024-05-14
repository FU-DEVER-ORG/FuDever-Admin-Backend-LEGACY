using FuDever.Application.Features.Position.CreatePosition;
using FuDever.WebApi.HttpResponseMapper.Entities.Position.CreatePosition.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Position.CreatePosition;

/// <summary>
///     Create position response status code
///     - position is already temporarily removed
///     http response.
/// </summary>
internal sealed class PositionIsAlreadyTemporarilyRemovedHttpResponse : CreatePositionHttpResponse
{
    internal PositionIsAlreadyTemporarilyRemovedHttpResponse(
        CreatePositionRequest request,
        CreatePositionResponse response
    )
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages =
        [
            $"Found position with name = {request.NewPositionName} in temporarily removed storage."
        ];
    }
}
