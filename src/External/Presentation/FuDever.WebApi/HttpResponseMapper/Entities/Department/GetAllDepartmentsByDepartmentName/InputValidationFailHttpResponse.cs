using FuDever.Application.Features.Department.GetAllDepartmentsByDepartmentName;
using FuDever.WebApi.HttpResponseMapper.Entities.Department.GetAllDepartmentsByDepartmentName.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Department.GetAllDepartmentsByDepartmentName;

/// <summary>
///     Get all departments by department name response status code
///     - input validation fail http response.
/// </summary>
internal sealed class InputValidationFailHttpResponse
    : GetAllDepartmentsByDepartmentNameHttpResponse
{
    internal InputValidationFailHttpResponse(GetAllDepartmentsByDepartmentNameResponse response)
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Input validation fail. Please check your inputs and try again."];
    }
}
