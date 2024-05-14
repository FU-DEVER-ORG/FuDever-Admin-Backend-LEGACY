using FuDever.Application.Features.Role.GetAllTemporarilyRemovedRoles;
using FuDever.WebApi.HttpResponseMapper.Entities.Role.GetAllTemporarilyRemovedRoles.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Role.GetAllTemporarilyRemovedRoles;

/// <summary>
///     Get all temporarily removed
///     roles response status code
///     - forbidden http response.
/// </summary>
internal sealed class ForbiddenHttpResponse : GetAllTemporarilyRemovedRolesHttpResponse
{
    internal ForbiddenHttpResponse(GetAllTemporarilyRemovedRolesResponse response)
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
    }
}
