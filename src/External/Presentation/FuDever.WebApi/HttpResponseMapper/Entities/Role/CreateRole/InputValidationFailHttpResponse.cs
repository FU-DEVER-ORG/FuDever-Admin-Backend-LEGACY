using FuDever.Application.Features.Role.CreateRole;
using FuDever.WebApi.HttpResponseMapper.Entities.Role.CreateRole.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Role.CreateRole;

/// <summary>
///     Create role response status code
///     - input validation fail http response.
/// </summary>
internal sealed class InputValidationFailHttpResponse : CreateRoleHttpResponse
{
    internal InputValidationFailHttpResponse(CreateRoleResponse response)
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Input validation fail. Please check your inputs and try again."];
    }
}
