using FuDever.Application.Features.Department.RemoveDepartmentPermanentlyByDepartmentId;
using FuDever.WebApi.HttpResponseMapper.Entities.Department.RemoveDepartmentPermanentlyByDepartmentId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Department.RemoveDepartmentPermanentlyByDepartmentId;

/// <summary>
///     Remove department permanently by department
///     Id response status code - department is not
///     found http response.
/// </summary>
internal sealed class DepartmentIsNotFoundHttpResponse
    : RemoveDepartmentPermanentlyByDepartmentIdHttpResponse
{
    internal DepartmentIsNotFoundHttpResponse(
        RemoveDepartmentPermanentlyByDepartmentIdRequest request,
        RemoveDepartmentPermanentlyByDepartmentIdResponse response
    )
    {
        HttpCode = StatusCodes.Status404NotFound;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"Department with Id = {request.DepartmentId} is not found."];
    }
}
