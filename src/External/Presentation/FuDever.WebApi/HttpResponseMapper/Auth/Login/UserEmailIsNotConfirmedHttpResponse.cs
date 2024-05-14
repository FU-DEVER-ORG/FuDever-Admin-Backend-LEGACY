using FuDever.Application.Features.Auth.Login;
using FuDever.WebApi.HttpResponseMapper.Auth.Login.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.Login;

/// <summary>
///     Login response status code
///     - user email is not confirmed
///     http response.
/// </summary>
internal sealed class UserEmailIsNotConfirmedHttpResponse : LoginHttpResponse
{
    internal UserEmailIsNotConfirmedHttpResponse(LoginRequest request, LoginResponse response)
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages =
        [
            $"User with username = {request.Username} has not confirmed account creation email."
        ];
    }
}
