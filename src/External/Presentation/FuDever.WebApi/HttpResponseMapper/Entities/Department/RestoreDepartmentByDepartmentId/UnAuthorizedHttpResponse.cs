using FuDever.Application.Features.Department.RestoreDepartmentByDepartmentId;
using FuDever.WebApi.HttpResponseMapper.Entities.Department.RestoreDepartmentByDepartmentId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Department.RestoreDepartmentByDepartmentId;

/// <summary>
///     Create department response status code
///     - un authorized http response.
/// </summary>
internal sealed class UnAuthorizedHttpResponse : RestoreDepartmentByDepartmentIdHttpResponse
{
    internal UnAuthorizedHttpResponse(RestoreDepartmentByDepartmentIdResponse response)
    {
        HttpCode = StatusCodes.Status401Unauthorized;
        AppCode = response.StatusCode.ToAppCode();
    }
}
