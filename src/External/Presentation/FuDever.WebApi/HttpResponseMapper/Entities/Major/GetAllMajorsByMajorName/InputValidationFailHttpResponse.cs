using FuDever.Application.Features.Major.GetAllMajorsByMajorName;
using FuDever.WebApi.HttpResponseMapper.Entities.Major.GetAllMajorsByMajorName.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Major.GetAllMajorsByMajorName;

/// <summary>
///     Get all majors by major name response status code
///     - input validation fail http response.
/// </summary>
internal sealed class InputValidationFailHttpResponse : GetAllMajorsByMajorNameHttpResponse
{
    internal InputValidationFailHttpResponse(GetAllMajorsByMajorNameResponse response)
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Input validation fail. Please check your inputs and try again."];
    }
}
