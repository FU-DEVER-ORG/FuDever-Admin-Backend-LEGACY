using FuDever.Application.Features.Role.CreateRole;
using FuDever.WebApi.HttpResponseMapper.Entities.Role.CreateRole.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Role.CreateRole;

/// <summary>
///     Create role response status code
///     - role is already temporarily removed
///     http response.
/// </summary>
internal sealed class RoleIsAlreadyTemporarilyRemovedHttpResponse : CreateRoleHttpResponse
{
    internal RoleIsAlreadyTemporarilyRemovedHttpResponse(
        CreateRoleRequest request,
        CreateRoleResponse response
    )
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages =
        [
            $"Found role with name = {request.NewRoleName} in temporarily removed storage."
        ];
    }
}
