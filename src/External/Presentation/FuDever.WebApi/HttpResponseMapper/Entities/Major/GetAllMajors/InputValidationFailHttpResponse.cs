using FuDever.Application.Features.Major.GetAllMajors;
using FuDever.WebApi.HttpResponseMapper.Entities.Major.GetAllMajors.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Major.GetAllMajors;

/// <summary>
///     Get all majors response status code
///     - input validation fail http response.
/// </summary>
internal sealed class InputValidationFailHttpResponse : GetAllMajorsHttpResponse
{
    internal InputValidationFailHttpResponse(GetAllMajorsResponse response)
    {
        HttpCode = StatusCodes.Status500InternalServerError;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Server error. Please try again later."];
    }
}
