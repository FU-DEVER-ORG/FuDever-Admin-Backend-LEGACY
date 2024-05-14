using FuDever.Application.Features.Auth.Login;
using FuDever.WebApi.HttpResponseMapper.Auth.Login.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.Login;

/// <summary>
///     Login response status code
///     - user password is not correct
///     http response.
/// </summary>
internal sealed class UserPasswordIsNotCorrectHttpResponse : LoginHttpResponse
{
    internal UserPasswordIsNotCorrectHttpResponse(LoginResponse response)
    {
        HttpCode = StatusCodes.Status404NotFound;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Password is not correct on this user."];
    }
}
