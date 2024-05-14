using FuDever.Application.Features.Auth.RequestForgotPassword;
using FuDever.WebApi.HttpResponseMapper.Auth.RequestForgotPassword.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.RequestForgotPassword;

/// <summary>
///     User is temporarily removed response status code
///     - user is temporarily removed
///     http response.
/// </summary>
internal sealed class UserIsTemporarilyRemovedHttpResponse : RequestForgotPasswordHttpResponse
{
    internal UserIsTemporarilyRemovedHttpResponse(RequestForgotPasswordResponse response)
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages =
        [
            "User has already been banned or blocked by Admin.",
            "Please contact with admin to recover your account."
        ];
    }
}
