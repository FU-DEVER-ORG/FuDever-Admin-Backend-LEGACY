using FuDever.Application.Features.Department.RemoveDepartmentTemporarilyByDepartmentId;
using FuDever.WebApi.HttpResponseMapper.Entities.Department.RemoveDepartmentTemporarilyByDepartmentId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Department.RemoveDepartmentTemporarilyByDepartmentId;

/// <summary>
///     Create department response status code
///     - un authorized http response.
/// </summary>
internal sealed class UnAuthorizedHttpResponse
    : RemoveDepartmentTemporarilyByDepartmentIdHttpResponse
{
    internal UnAuthorizedHttpResponse(RemoveDepartmentTemporarilyByDepartmentIdResponse response)
    {
        HttpCode = StatusCodes.Status401Unauthorized;
        AppCode = response.StatusCode.ToAppCode();
    }
}
