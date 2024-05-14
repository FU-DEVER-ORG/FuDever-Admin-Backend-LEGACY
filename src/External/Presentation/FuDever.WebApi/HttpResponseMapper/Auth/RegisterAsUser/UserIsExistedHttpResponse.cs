using FuDever.Application.Features.Auth.RegisterAsUser;
using FuDever.WebApi.HttpResponseMapper.Auth.RegisterAsUser.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.RegisterAsUser;

/// <summary>
///     Register as user response status code
///     - user is existed http response.
/// </summary>
internal sealed class UserIsExistedHttpResponse : RegisterAsUserHttpResponse
{
    internal UserIsExistedHttpResponse(
        RegisterAsUserRequest request,
        RegisterAsUserResponse response
    )
    {
        HttpCode = StatusCodes.Status409Conflict;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"User with username = {request.Username} already exists"];
    }
}
