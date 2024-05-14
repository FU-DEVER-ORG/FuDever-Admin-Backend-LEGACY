using FuDever.Application.Features.Role.RemoveRolePermanentlyByRoleId;
using FuDever.WebApi.HttpResponseMapper.Entities.Role.RemoveRolePermanentlyByRoleId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Role.RemoveRolePermanentlyByRoleId;

/// <summary>
///     Remove role permanently by role
///     Id response status code - role id not
///     found http response.
/// </summary>
internal sealed class RoleIsNotTemporarilyRemovedHttpResponse
    : RemoveRolePermanentlyByRoleIdHttpResponse
{
    internal RoleIsNotTemporarilyRemovedHttpResponse(
        RemoveRolePermanentlyByRoleIdRequest request,
        RemoveRolePermanentlyByRoleIdResponse response
    )
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages =
        [
            $"Role with Id = {request.RoleId} is not found in temporarily removed storage."
        ];
    }
}
