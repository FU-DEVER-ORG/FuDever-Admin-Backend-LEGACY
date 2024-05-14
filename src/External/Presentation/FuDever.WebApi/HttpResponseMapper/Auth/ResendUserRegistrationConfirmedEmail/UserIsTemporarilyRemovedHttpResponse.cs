using FuDever.Application.Features.Auth.ResendUserRegistrationConfirmedEmail;
using FuDever.WebApi.HttpResponseMapper.Auth.ResendUserRegistrationConfirmedEmail.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.ResendUserRegistrationConfirmedEmail;

/// <summary>
///     Resend user registration confirmed
///     email response status code
///     - user is temporarily removed
///     http response.
/// </summary>
internal sealed class UserIsTemporarilyRemovedHttpResponse
    : ResendUserRegistrationConfirmedEmailHttpResponse
{
    internal UserIsTemporarilyRemovedHttpResponse(
        ResendUserRegistrationConfirmedEmailResponse response
    )
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
