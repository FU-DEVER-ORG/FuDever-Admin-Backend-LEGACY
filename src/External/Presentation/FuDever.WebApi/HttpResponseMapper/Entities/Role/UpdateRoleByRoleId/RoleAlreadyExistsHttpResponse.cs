using FuDever.Application.Features.Role.UpdateRoleByRoleId;
using FuDever.WebApi.HttpResponseMapper.Entities.Role.UpdateRoleByRoleId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Role.UpdateRoleByRoleId;

/// <summary>
///     Update role by role id response
///     status code - role already exists
///     http response.
/// </summary>
internal sealed class RoleAlreadyExistsHttpResponse : UpdateRoleByRoleIdHttpResponse
{
    internal RoleAlreadyExistsHttpResponse(
        UpdateRoleByRoleIdRequest request,
        UpdateRoleByRoleIdResponse response
    )
    {
        HttpCode = StatusCodes.Status409Conflict;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"Role with name = {request.NewRoleName} already exists."];
    }
}
