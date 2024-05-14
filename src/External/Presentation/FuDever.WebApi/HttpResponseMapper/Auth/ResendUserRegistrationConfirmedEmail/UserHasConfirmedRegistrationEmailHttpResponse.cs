using FuDever.Application.Features.Auth.ResendUserRegistrationConfirmedEmail;
using FuDever.WebApi.HttpResponseMapper.Auth.ResendUserRegistrationConfirmedEmail.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.ResendUserRegistrationConfirmedEmail;

/// <summary>
///     Confirm user registration confirmed email
///     response status code -
///     - user has confirmed the registration
///     email http response.
/// </summary>
internal sealed class UserHasConfirmedRegistrationEmailHttpResponse
    : ResendUserRegistrationConfirmedEmailHttpResponse
{
    internal UserHasConfirmedRegistrationEmailHttpResponse(
        ResendUserRegistrationConfirmedEmailResponse response
    )
    {
        HttpCode = StatusCodes.Status409Conflict;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["User has already confirmed the registration email."];
    }
}
