using FuDever.Application.Features.Department.UpdateDepartmentByDepartmentId;
using FuDever.WebApi.HttpResponseMapper.Entities.Department.UpdateDepartmentByDepartmentId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Department.UpdateDepartmentByDepartmentId;

/// <summary>
///     Create department response status code
///     - forbidden http response.
/// </summary>
internal sealed class ForbiddenHttpResponse : UpdateDepartmentByDepartmentIdHttpResponse
{
    internal ForbiddenHttpResponse(UpdateDepartmentByDepartmentIdResponse response)
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
    }
}
