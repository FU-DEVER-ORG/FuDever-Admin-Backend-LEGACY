using FuDever.Application.Features.Role.CreateRole;
using FuDever.WebApi.HttpResponseMapper.Entities.Role.CreateRole.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Role.CreateRole;

/// <summary>
///     Create role response status code
///     - un authorized http response.
/// </summary>
internal sealed class UnAuthorizedHttpResponse : CreateRoleHttpResponse
{
    internal UnAuthorizedHttpResponse(CreateRoleResponse response)
    {
        HttpCode = StatusCodes.Status401Unauthorized;
        AppCode = response.StatusCode.ToAppCode();
    }
}
