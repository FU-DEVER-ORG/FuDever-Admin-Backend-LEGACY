using FuDever.Application.Features.Auth.Login;
using FuDever.WebApi.HttpResponseMapper.Auth.Login.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.Login;

/// <summary>
///     Login response status code
///     - user is locked out http response.
/// </summary>
internal sealed class UserIsLockedOutHttpResponse : LoginHttpResponse
{
    internal UserIsLockedOutHttpResponse(LoginRequest request, LoginResponse response)
    {
        HttpCode = StatusCodes.Status429TooManyRequests;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages =
        [
            $"User with username = {request.Username} has been temporarily locked due to entering the wrong password too many times",
            $"Please try again after 15 seconds."
        ];
    }
}
