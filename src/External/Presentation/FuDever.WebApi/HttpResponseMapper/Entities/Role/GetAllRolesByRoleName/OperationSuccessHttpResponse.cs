using FuDever.Application.Features.Role.GetAllRolesByRoleName;
using FuDever.WebApi.HttpResponseMapper.Entities.Role.GetAllRolesByRoleName.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Role.GetAllRolesByRoleName;

/// <summary>
///     Get all roles by role name response status code
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : GetAllRolesByRoleNameHttpResponse
{
    internal OperationSuccessHttpResponse(GetAllRolesByRoleNameResponse response)
    {
        HttpCode = StatusCodes.Status200OK;
        AppCode = response.StatusCode.ToAppCode();
        Body = response.FoundRoles;
    }
}
