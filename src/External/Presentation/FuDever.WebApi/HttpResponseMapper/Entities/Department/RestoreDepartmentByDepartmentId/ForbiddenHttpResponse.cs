using FuDever.Application.Features.Department.RestoreDepartmentByDepartmentId;
using FuDever.WebApi.HttpResponseMapper.Entities.Department.RestoreDepartmentByDepartmentId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Department.RestoreDepartmentByDepartmentId;

/// <summary>
///     Create department response status code
///     - forbidden http response.
/// </summary>
internal sealed class ForbiddenHttpResponse : RestoreDepartmentByDepartmentIdHttpResponse
{
    internal ForbiddenHttpResponse(RestoreDepartmentByDepartmentIdResponse response)
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
    }
}
