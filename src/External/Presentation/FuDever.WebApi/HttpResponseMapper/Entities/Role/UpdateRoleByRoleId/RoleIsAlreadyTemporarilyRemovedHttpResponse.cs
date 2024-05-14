using FuDever.Application.Features.Role.UpdateRoleByRoleId;
using FuDever.WebApi.HttpResponseMapper.Entities.Role.UpdateRoleByRoleId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Role.UpdateRoleByRoleId;

/// <summary>
///     Update role by role
///     Id response status code - role is already
///     temporarily removed http response.
/// </summary>
internal sealed class RoleIsAlreadyTemporarilyRemovedHttpResponse : UpdateRoleByRoleIdHttpResponse
{
    internal RoleIsAlreadyTemporarilyRemovedHttpResponse(
        UpdateRoleByRoleIdRequest request,
        UpdateRoleByRoleIdResponse response
    )
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"Found role with Id = {request.RoleId} in temporarily removed storage."];
    }
}
