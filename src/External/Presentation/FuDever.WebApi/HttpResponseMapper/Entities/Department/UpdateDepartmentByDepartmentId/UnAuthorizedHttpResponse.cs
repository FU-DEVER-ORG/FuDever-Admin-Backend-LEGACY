using FuDever.Application.Features.Department.UpdateDepartmentByDepartmentId;
using FuDever.WebApi.HttpResponseMapper.Entities.Department.UpdateDepartmentByDepartmentId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Department.UpdateDepartmentByDepartmentId;

/// <summary>
///     Create department response status code
///     - un authorized http response.
/// </summary>
internal sealed class UnAuthorizedHttpResponse : UpdateDepartmentByDepartmentIdHttpResponse
{
    internal UnAuthorizedHttpResponse(UpdateDepartmentByDepartmentIdResponse response)
    {
        HttpCode = StatusCodes.Status401Unauthorized;
        AppCode = response.StatusCode.ToAppCode();
    }
}
