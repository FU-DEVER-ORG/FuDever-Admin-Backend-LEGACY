using FuDever.Application.Features.Position.GetAllTemporarilyRemovedPositions;
using FuDever.WebApi.HttpResponseMapper.Entities.Position.GetAllTemporarilyRemovedPositions.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Position.GetAllTemporarilyRemovedPositions;

/// <summary>
///     Get all temporarily removed positions response status code
///     - input validation fail http response.
/// </summary>
internal sealed class InputValidationFailHttpResponse
    : GetAllTemporarilyRemovedPositionsHttpResponse
{
    internal InputValidationFailHttpResponse(GetAllTemporarilyRemovedPositionsResponse response)
    {
        HttpCode = StatusCodes.Status500InternalServerError;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Server error. Please try again later."];
    }
}
