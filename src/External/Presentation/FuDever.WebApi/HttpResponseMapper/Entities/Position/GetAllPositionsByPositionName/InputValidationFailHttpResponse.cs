using FuDever.Application.Features.Position.GetAllPositionsByPositionName;
using FuDever.WebApi.HttpResponseMapper.Entities.Position.GetAllPositionsByPositionName.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Position.GetAllPositionsByPositionName;

/// <summary>
///     Get all positions by position name response status code
///     - input validation fail http response.
/// </summary>
internal sealed class InputValidationFailHttpResponse : GetAllPositionsByPositionNameHttpResponse
{
    internal InputValidationFailHttpResponse(GetAllPositionsByPositionNameResponse response)
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Input validation fail. Please check your inputs and try again."];
    }
}
