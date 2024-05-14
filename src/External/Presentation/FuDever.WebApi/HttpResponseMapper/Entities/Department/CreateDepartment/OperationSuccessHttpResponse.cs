using FuDever.Application.Features.Auth.Login;
using FuDever.Application.Features.Department.CreateDepartment;
using FuDever.WebApi.HttpResponseMapper.Entities.Department.CreateDepartment.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Department.CreateDepartment;

/// <summary>
///     Create department response status code
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : CreateDepartmentHttpResponse
{
    internal OperationSuccessHttpResponse(CreateDepartmentResponse response)
    {
        HttpCode = StatusCodes.Status201Created;
        AppCode = response.StatusCode.ToAppCode();
    }
}
