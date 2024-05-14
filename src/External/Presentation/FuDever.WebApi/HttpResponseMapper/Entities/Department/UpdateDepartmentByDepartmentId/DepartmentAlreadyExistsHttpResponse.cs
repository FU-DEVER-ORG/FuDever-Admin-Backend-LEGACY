using FuDever.Application.Features.Department.UpdateDepartmentByDepartmentId;
using FuDever.WebApi.HttpResponseMapper.Entities.Department.UpdateDepartmentByDepartmentId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Department.UpdateDepartmentByDepartmentId;

/// <summary>
///     Update department by department id response
///     status code - department already exists
///     http response.
/// </summary>
internal sealed class DepartmentAlreadyExistsHttpResponse
    : UpdateDepartmentByDepartmentIdHttpResponse
{
    internal DepartmentAlreadyExistsHttpResponse(
        UpdateDepartmentByDepartmentIdRequest request,
        UpdateDepartmentByDepartmentIdResponse response
    )
    {
        HttpCode = StatusCodes.Status409Conflict;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"Department with name = {request.NewDepartmentName} already exists."];
    }
}
