using FuDever.Application.Features.Auth.Login;
using FuDever.Application.Features.Department.CreateDepartment;
using FuDever.WebApi.HttpResponseMapper.Entities.Department.CreateDepartment.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Department.CreateDepartment;

/// <summary>
///     Create department response status code
///     - department already exists http response.
/// </summary>
internal sealed class DepartmentAlreadyExistsHttpResponse : CreateDepartmentHttpResponse
{
    internal DepartmentAlreadyExistsHttpResponse(
        CreateDepartmentRequest request,
        CreateDepartmentResponse response
    )
    {
        HttpCode = StatusCodes.Status409Conflict;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"Department with name = {request.NewDepartmentName} already exists."];
    }
}
