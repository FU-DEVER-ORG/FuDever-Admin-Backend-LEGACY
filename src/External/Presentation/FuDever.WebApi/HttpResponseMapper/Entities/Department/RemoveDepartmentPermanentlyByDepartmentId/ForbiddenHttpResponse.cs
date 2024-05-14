using FuDever.Application.Features.Department.RemoveDepartmentPermanentlyByDepartmentId;
using FuDever.WebApi.HttpResponseMapper.Entities.Department.RemoveDepartmentPermanentlyByDepartmentId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Department.RemoveDepartmentPermanentlyByDepartmentId;

/// <summary>
///     Create department response status code
///     - forbidden http response.
/// </summary>
internal sealed class ForbiddenHttpResponse : RemoveDepartmentPermanentlyByDepartmentIdHttpResponse
{
    internal ForbiddenHttpResponse(RemoveDepartmentPermanentlyByDepartmentIdResponse response)
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
    }
}
