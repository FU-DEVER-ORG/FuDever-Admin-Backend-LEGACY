using FuDever.Application.Features.Role.RestoreRoleByRoleId;
using FuDever.WebApi.HttpResponseMapper.Entities.Role.RestoreRoleByRoleId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Role.RestoreRoleByRoleId;

/// <summary>
///     Restore role by role
///     Id response status code - role is not
///     found http response.
/// </summary>
internal sealed class RoleIsNotFoundHttpResponse : RestoreRoleByRoleIdHttpResponse
{
    internal RoleIsNotFoundHttpResponse(
        RestoreRoleByRoleIdRequest request,
        RestoreRoleByRoleIdResponse response
    )
    {
        HttpCode = StatusCodes.Status404NotFound;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"Role with Id = {request.RoleId} is not found."];
    }
}
