using FuDever.Application.Features.Department.GetAllDepartments;
using FuDever.WebApi.HttpResponseMapper.Entities.Department.GetAllDepartments.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Department.GetAllDepartments;

/// <summary>
///     Get all departments response status code
///     - input validation fail http response.
/// </summary>
internal sealed class InputValidationFailHttpResponse : GetAllDepartmentsHttpResponse
{
    internal InputValidationFailHttpResponse(GetAllDepartmentsResponse response)
    {
        HttpCode = StatusCodes.Status500InternalServerError;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Server error. Please try again later."];
    }
}
