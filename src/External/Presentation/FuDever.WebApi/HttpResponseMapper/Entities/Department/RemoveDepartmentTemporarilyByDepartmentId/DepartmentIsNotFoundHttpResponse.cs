using FuDever.Application.Features.Department.RemoveDepartmentTemporarilyByDepartmentId;
using FuDever.WebApi.HttpResponseMapper.Entities.Department.RemoveDepartmentTemporarilyByDepartmentId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Department.RemoveDepartmentTemporarilyByDepartmentId;

/// <summary>
///     Remove department temporarily by department
///     Id response status code - department is not
///     found http response.
/// </summary>
internal sealed class DepartmentIsNotFoundHttpResponse
    : RemoveDepartmentTemporarilyByDepartmentIdHttpResponse
{
    internal DepartmentIsNotFoundHttpResponse(
        RemoveDepartmentTemporarilyByDepartmentIdRequest request,
        RemoveDepartmentTemporarilyByDepartmentIdResponse response
    )
    {
        HttpCode = StatusCodes.Status404NotFound;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"Department with Id = {request.DepartmentId} is not found."];
    }
}
