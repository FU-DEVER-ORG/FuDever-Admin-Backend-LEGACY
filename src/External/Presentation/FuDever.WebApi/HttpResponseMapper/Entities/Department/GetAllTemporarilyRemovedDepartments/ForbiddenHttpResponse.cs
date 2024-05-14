using FuDever.Application.Features.Department.GetAllTemporarilyRemovedDepartments;
using FuDever.WebApi.HttpResponseMapper.Entities.Department.GetAllTemporarilyRemovedDepartments.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Department.GetAllTemporarilyRemovedDepartments;

/// <summary>
///     Create department response status code
///     - forbidden http response.
/// </summary>
internal sealed class ForbiddenHttpResponse : GetAllTemporarilyRemovedDepartmentsHttpResponse
{
    internal ForbiddenHttpResponse(GetAllTemporarilyRemovedDepartmentsResponse response)
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
    }
}
