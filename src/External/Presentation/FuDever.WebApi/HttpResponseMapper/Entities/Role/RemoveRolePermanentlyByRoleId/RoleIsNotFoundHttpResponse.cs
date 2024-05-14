using FuDever.Application.Features.Role.RemoveRolePermanentlyByRoleId;
using FuDever.WebApi.HttpResponseMapper.Entities.Role.RemoveRolePermanentlyByRoleId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Role.RemoveRolePermanentlyByRoleId;

/// <summary>
///     Remove role permanently by role
///     Id response status code - role is not
///     found http response.
/// </summary>
internal sealed class RoleIsNotFoundHttpResponse : RemoveRolePermanentlyByRoleIdHttpResponse
{
    internal RoleIsNotFoundHttpResponse(
        RemoveRolePermanentlyByRoleIdRequest request,
        RemoveRolePermanentlyByRoleIdResponse response
    )
    {
        HttpCode = StatusCodes.Status404NotFound;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"Role with Id = {request.RoleId} is not found."];
    }
}
