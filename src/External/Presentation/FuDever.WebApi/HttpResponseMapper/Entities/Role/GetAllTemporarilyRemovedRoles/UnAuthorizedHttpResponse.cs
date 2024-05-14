using FuDever.Application.Features.Role.GetAllTemporarilyRemovedRoles;
using FuDever.WebApi.HttpResponseMapper.Entities.Role.GetAllTemporarilyRemovedRoles.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Role.GetAllTemporarilyRemovedRoles;

/// <summary>
///     Get all temporarily removed roles response status code
///     - un authorized http response.
/// </summary>
internal sealed class UnAuthorizedHttpResponse : GetAllTemporarilyRemovedRolesHttpResponse
{
    internal UnAuthorizedHttpResponse(GetAllTemporarilyRemovedRolesResponse response)
    {
        HttpCode = StatusCodes.Status401Unauthorized;
        AppCode = response.StatusCode.ToAppCode();
    }
}
