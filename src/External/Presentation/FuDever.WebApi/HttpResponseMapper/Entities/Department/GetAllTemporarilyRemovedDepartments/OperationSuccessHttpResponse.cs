using FuDever.Application.Features.Department.GetAllTemporarilyRemovedDepartments;
using FuDever.WebApi.HttpResponseMapper.Entities.Department.GetAllTemporarilyRemovedDepartments.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Department.GetAllTemporarilyRemovedDepartments;

/// <summary>
///     Get all temporarily removed departments response status code
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : GetAllTemporarilyRemovedDepartmentsHttpResponse
{
    internal OperationSuccessHttpResponse(GetAllTemporarilyRemovedDepartmentsResponse response)
    {
        HttpCode = StatusCodes.Status200OK;
        AppCode = response.StatusCode.ToAppCode();
        Body = response.FoundTemporarilyRemovedDepartments;
    }
}
