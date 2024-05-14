using FuDever.Application.Features.Role.GetAllRoles;
using FuDever.WebApi.HttpResponseMapper.Entities.Role.GetAllRoles.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Role.GetAllRoles;

/// <summary>
///     Get all roles response status code
///     - input validation fail http response.
/// </summary>
internal sealed class InputValidationFailHttpResponse : GetAllRolesHttpResponse
{
    internal InputValidationFailHttpResponse(GetAllRolesResponse response)
    {
        HttpCode = StatusCodes.Status500InternalServerError;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Server error. Please try again later."];
    }
}
