using FuDever.Application.Features.Auth.RegisterAsUser;
using FuDever.WebApi.HttpResponseMapper.Auth.RegisterAsUser.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.RegisterAsUser;

/// <summary>
///     Register as user response status code
///     - username is not a real email
///     http response.
/// </summary>
internal sealed class UsernameIsNotARealEmailHttpResponse : RegisterAsUserHttpResponse
{
    internal UsernameIsNotARealEmailHttpResponse(
        RegisterAsUserRequest request,
        RegisterAsUserResponse response
    )
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"User with username(email) = {request.Username} is not real"];
    }
}
