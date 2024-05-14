using FuDever.Application.Features.Role.CreateRole;
using FuDever.WebApi.HttpResponseMapper.Entities.Role.CreateRole.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Role.CreateRole;

/// <summary>
///     Create role response status code
///     - forbidden http response.
/// </summary>
internal sealed class ForbiddenHttpResponse : CreateRoleHttpResponse
{
    internal ForbiddenHttpResponse(CreateRoleResponse response)
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
    }
}
