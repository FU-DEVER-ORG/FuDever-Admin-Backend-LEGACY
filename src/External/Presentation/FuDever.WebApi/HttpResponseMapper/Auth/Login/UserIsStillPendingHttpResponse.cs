using FuDever.Application.Features.Auth.Login;
using FuDever.WebApi.HttpResponseMapper.Auth.Login.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.Login;

/// <summary>
///     Login response status code
///     - user is still pending http response.
/// </summary>
internal sealed class UserIsStillPendingHttpResponse : LoginHttpResponse
{
    internal UserIsStillPendingHttpResponse(LoginRequest request, LoginResponse response)
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages =
        [
            $"User account with username = {request.Username} is still in pending state.",
            "Please wait for admin consideration on this account."
        ];
    }
}
