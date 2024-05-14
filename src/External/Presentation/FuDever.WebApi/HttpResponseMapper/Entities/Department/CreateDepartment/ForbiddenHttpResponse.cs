using FuDever.Application.Features.Auth.Login;
using FuDever.Application.Features.Department.CreateDepartment;
using FuDever.WebApi.HttpResponseMapper.Entities.Department.CreateDepartment.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Department.CreateDepartment;

/// <summary>
///     Create department response status code
///     - forbidden http response.
/// </summary>
internal sealed class ForbiddenHttpResponse : CreateDepartmentHttpResponse
{
    internal ForbiddenHttpResponse(CreateDepartmentResponse response)
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
    }
}
