using FuDever.Application.Features.Role.CreateRole;
using FuDever.WebApi.HttpResponseMapper.Entities.Role.CreateRole.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Role.CreateRole;

/// <summary>
///     Create role response status code
///     - role already exists http response.
/// </summary>
internal sealed class RoleAlreadyExistsHttpResponse : CreateRoleHttpResponse
{
    internal RoleAlreadyExistsHttpResponse(CreateRoleRequest request, CreateRoleResponse response)
    {
        HttpCode = StatusCodes.Status409Conflict;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"Role with name = {request.NewRoleName} already exists."];
    }
}
