using FuDever.Application.Features.Major.GetAllTemporarilyRemovedMajors;
using FuDever.WebApi.HttpResponseMapper.Entities.Major.GetAllTemporarilyRemovedMajors.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Major.GetAllTemporarilyRemovedMajors;

/// <summary>
///     Get all temporarily removed majors response status code
///     - input validation fail http response.
/// </summary>
internal sealed class InputValidationFailHttpResponse : GetAllTemporarilyRemovedMajorsHttpResponse
{
    internal InputValidationFailHttpResponse(GetAllTemporarilyRemovedMajorsResponse response)
    {
        HttpCode = StatusCodes.Status500InternalServerError;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Server error. Please try again later."];
    }
}
