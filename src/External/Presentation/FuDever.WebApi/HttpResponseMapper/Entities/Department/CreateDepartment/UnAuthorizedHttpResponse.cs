using FuDever.Application.Features.Auth.Login;
using FuDever.Application.Features.Department.CreateDepartment;
using FuDever.WebApi.HttpResponseMapper.Entities.Department.CreateDepartment.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Department.CreateDepartment;

/// <summary>
///     Create department response status code
///     - un authorized http response.
/// </summary>
internal sealed class UnAuthorizedHttpResponse : CreateDepartmentHttpResponse
{
    internal UnAuthorizedHttpResponse(CreateDepartmentResponse response)
    {
        HttpCode = StatusCodes.Status401Unauthorized;
        AppCode = response.StatusCode.ToAppCode();
    }
}
