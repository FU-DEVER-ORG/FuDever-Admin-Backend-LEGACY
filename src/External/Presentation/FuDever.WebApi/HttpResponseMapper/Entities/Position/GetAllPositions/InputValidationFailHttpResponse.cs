using FuDever.Application.Features.Position.GetAllPositions;
using FuDever.WebApi.HttpResponseMapper.Entities.Position.GetAllPositions.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Position.GetAllPositions;

/// <summary>
///     Get all positions response status code
///     - input validation fail http response.
/// </summary>
internal sealed class InputValidationFailHttpResponse : GetAllPositionsHttpResponse
{
    internal InputValidationFailHttpResponse(GetAllPositionsResponse response)
    {
        HttpCode = StatusCodes.Status500InternalServerError;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Server error. Please try again later."];
    }
}
