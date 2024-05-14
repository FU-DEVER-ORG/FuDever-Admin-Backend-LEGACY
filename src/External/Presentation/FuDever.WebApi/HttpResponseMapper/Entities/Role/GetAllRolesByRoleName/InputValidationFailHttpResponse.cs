using FuDever.Application.Features.Role.GetAllRolesByRoleName;
using FuDever.WebApi.HttpResponseMapper.Entities.Role.GetAllRolesByRoleName.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Role.GetAllRolesByRoleName;

/// <summary>
///     Get all roles by role name response status code
///     - input validation fail http response.
/// </summary>
internal sealed class InputValidationFailHttpResponse : GetAllRolesByRoleNameHttpResponse
{
    internal InputValidationFailHttpResponse(GetAllRolesByRoleNameResponse response)
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Input validation fail. Please check your inputs and try again."];
    }
}
