using FuDever.Application.Features.Auth.ConfirmUserRegistrationConfirmedEmail;
using FuDever.WebApi.HttpResponseMapper.Auth.ConfirmUserRegistrationConfirmedEmail.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.ConfirmUserRegistrationConfirmedEmail;

/// <summary>
///     Confirm user registration confirmed
///     email response status code
///     - user is temporarily removed
///     http response.
/// </summary>
internal sealed class UserIsTemporarilyRemovedHttpResponse
    : ConfirmUserRegistrationConfirmedEmailHttpResponse
{
    internal UserIsTemporarilyRemovedHttpResponse(
        ConfirmUserRegistrationConfirmedEmailResponse response
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
