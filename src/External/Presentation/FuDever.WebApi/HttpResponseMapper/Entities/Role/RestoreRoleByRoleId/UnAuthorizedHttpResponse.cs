using FuDever.Application.Features.Role.RestoreRoleByRoleId;
using FuDever.WebApi.HttpResponseMapper.Entities.Role.RestoreRoleByRoleId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Role.RestoreRoleByRoleId;

/// <summary>
///     Restore role by role
///     Id response status code
///     - un authorized http response.
/// </summary>
internal sealed class UnAuthorizedHttpResponse : RestoreRoleByRoleIdHttpResponse
{
    internal UnAuthorizedHttpResponse(RestoreRoleByRoleIdResponse response)
    {
        HttpCode = StatusCodes.Status401Unauthorized;
        AppCode = response.StatusCode.ToAppCode();
    }
}
