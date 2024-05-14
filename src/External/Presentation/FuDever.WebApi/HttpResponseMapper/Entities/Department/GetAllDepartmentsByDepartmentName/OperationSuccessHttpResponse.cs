using FuDever.Application.Features.Department.GetAllDepartmentsByDepartmentName;
using FuDever.WebApi.HttpResponseMapper.Entities.Department.GetAllDepartmentsByDepartmentName.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Department.GetAllDepartmentsByDepartmentName;

/// <summary>
///     Get all departments by department name response status code
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : GetAllDepartmentsByDepartmentNameHttpResponse
{
    internal OperationSuccessHttpResponse(GetAllDepartmentsByDepartmentNameResponse response)
    {
        HttpCode = StatusCodes.Status200OK;
        AppCode = response.StatusCode.ToAppCode();
        Body = response.FoundDepartments;
    }
}
