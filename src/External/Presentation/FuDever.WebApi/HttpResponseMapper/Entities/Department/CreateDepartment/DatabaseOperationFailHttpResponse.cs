using FuDever.Application.Features.Auth.Login;
using FuDever.Application.Features.Department.CreateDepartment;
using FuDever.WebApi.HttpResponseMapper.Entities.Department.CreateDepartment.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Department.CreateDepartment;

/// <summary>
///     Create department response status code
///     - database operation fail http response.
/// </summary>
internal sealed class DatabaseOperationFailHttpResponse : CreateDepartmentHttpResponse
{
    internal DatabaseOperationFailHttpResponse(CreateDepartmentResponse response)
    {
        HttpCode = StatusCodes.Status500InternalServerError;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Server error !!!."];
    }
}
