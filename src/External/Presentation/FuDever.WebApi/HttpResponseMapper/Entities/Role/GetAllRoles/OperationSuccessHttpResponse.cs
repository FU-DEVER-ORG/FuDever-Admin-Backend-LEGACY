using FuDever.Application.Features.Role.GetAllRoles;
using FuDever.WebApi.HttpResponseMapper.Entities.Role.GetAllRoles.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Role.GetAllRoles;

/// <summary>
///     Get all roles response status code
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : GetAllRolesHttpResponse
{
    internal OperationSuccessHttpResponse(GetAllRolesResponse response)
    {
        HttpCode = StatusCodes.Status200OK;
        AppCode = response.StatusCode.ToAppCode();
        Body = response.FoundRoles;
    }
}
