using FuDever.Application.Features.Auth.Login;
using FuDever.WebApi.HttpResponseMapper.Auth.Login.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.Login;

/// <summary>
///     Login response status code
///     - user is not found http response.
/// </summary>
internal sealed class UserIsNotFoundHttpResponse : LoginHttpResponse
{
    internal UserIsNotFoundHttpResponse(LoginRequest request, LoginResponse response)
    {
        HttpCode = StatusCodes.Status404NotFound;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"User with username = {request.Username} is not found."];
    }
}
