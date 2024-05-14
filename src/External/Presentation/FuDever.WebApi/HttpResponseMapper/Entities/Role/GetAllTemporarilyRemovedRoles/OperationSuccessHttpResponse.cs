using FuDever.Application.Features.Role.GetAllTemporarilyRemovedRoles;
using FuDever.WebApi.HttpResponseMapper.Entities.Role.GetAllTemporarilyRemovedRoles.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Role.GetAllTemporarilyRemovedRoles;

/// <summary>
///     Get all temporarily removed roles response status code
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : GetAllTemporarilyRemovedRolesHttpResponse
{
    internal OperationSuccessHttpResponse(GetAllTemporarilyRemovedRolesResponse response)
    {
        HttpCode = StatusCodes.Status200OK;
        AppCode = response.StatusCode.ToAppCode();
        Body = response.FoundTemporarilyRemovedRoles;
    }
}
