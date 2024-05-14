using FuDever.Application.Features.Department.GetAllTemporarilyRemovedDepartments;
using FuDever.WebApi.HttpResponseMapper.Entities.Department.GetAllTemporarilyRemovedDepartments.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Department.GetAllTemporarilyRemovedDepartments;

/// <summary>
///     Create department response status code
///     - un authorized http response.
/// </summary>
internal sealed class UnAuthorizedHttpResponse : GetAllTemporarilyRemovedDepartmentsHttpResponse
{
    internal UnAuthorizedHttpResponse(GetAllTemporarilyRemovedDepartmentsResponse response)
    {
        HttpCode = StatusCodes.Status401Unauthorized;
        AppCode = response.StatusCode.ToAppCode();
    }
}
