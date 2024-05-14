using FuDever.Application.Features.Department.GetAllDepartments;
using FuDever.WebApi.HttpResponseMapper.Entities.Department.GetAllDepartments.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Department.GetAllDepartments;

/// <summary>
///     Get all departments response status code
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : GetAllDepartmentsHttpResponse
{
    internal OperationSuccessHttpResponse(GetAllDepartmentsResponse response)
    {
        HttpCode = StatusCodes.Status200OK;
        AppCode = response.StatusCode.ToAppCode();
        Body = response.FoundDepartments;
    }
}
