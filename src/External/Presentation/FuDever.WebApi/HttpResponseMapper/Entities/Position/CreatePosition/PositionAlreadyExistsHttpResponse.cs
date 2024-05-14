using FuDever.Application.Features.Position.CreatePosition;
using FuDever.WebApi.HttpResponseMapper.Entities.Position.CreatePosition.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Position.CreatePosition;

/// <summary>
///     Create position response status code
///     - position already exists http response.
/// </summary>
internal sealed class PositionAlreadyExistsHttpResponse : CreatePositionHttpResponse
{
    internal PositionAlreadyExistsHttpResponse(
        CreatePositionRequest request,
        CreatePositionResponse response
    )
    {
        HttpCode = StatusCodes.Status409Conflict;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"Position with name = {request.NewPositionName} already exists."];
    }
}
