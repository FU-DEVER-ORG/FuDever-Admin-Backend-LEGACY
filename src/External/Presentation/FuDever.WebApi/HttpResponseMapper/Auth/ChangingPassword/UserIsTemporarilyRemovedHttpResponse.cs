using FuDever.Application.Features.Auth.ChangingPassword;
using FuDever.WebApi.HttpResponseMapper.Auth.ChangingPassword.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.ChangingPassword;

/// <summary>
///     Changing password response status code
///     - user is temporarily removed
///     http response.
/// </summary>
internal sealed class UserIsTemporarilyRemovedHttpResponse : ChangingPasswordHttpResponse
{
    internal UserIsTemporarilyRemovedHttpResponse(ChangingPasswordResponse response)
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
