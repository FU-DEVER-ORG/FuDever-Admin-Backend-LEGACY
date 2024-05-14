using FuDever.Application.Features.Auth.Login;
using FuDever.WebApi.HttpResponseMapper.Auth.Login.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.Login;

/// <summary>
///     Login response status code
///     - user is already rejected http response.
/// </summary>
internal sealed class UserIsAlreadyRejectedHttpResponse : LoginHttpResponse
{
    internal UserIsAlreadyRejectedHttpResponse(LoginRequest request, LoginResponse response)
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"User account with username = {request.Username} is rejected by admin."];
    }
}
