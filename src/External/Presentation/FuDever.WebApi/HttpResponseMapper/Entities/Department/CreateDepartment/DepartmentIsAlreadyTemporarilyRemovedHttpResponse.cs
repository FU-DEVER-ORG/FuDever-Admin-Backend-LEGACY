using FuDever.Application.Features.Auth.Login;
using FuDever.Application.Features.Department.CreateDepartment;
using FuDever.WebApi.HttpResponseMapper.Entities.Department.CreateDepartment.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Department.CreateDepartment;

/// <summary>
///     Create department response status code
///     - department is already temporarily removed
///     http response.
/// </summary>
internal sealed class DepartmentIsAlreadyTemporarilyRemovedHttpResponse
    : CreateDepartmentHttpResponse
{
    internal DepartmentIsAlreadyTemporarilyRemovedHttpResponse(
        CreateDepartmentRequest request,
        CreateDepartmentResponse response
    )
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages =
        [
            $"Found department with name = {request.NewDepartmentName} in temporarily removed storage."
        ];
    }
}
