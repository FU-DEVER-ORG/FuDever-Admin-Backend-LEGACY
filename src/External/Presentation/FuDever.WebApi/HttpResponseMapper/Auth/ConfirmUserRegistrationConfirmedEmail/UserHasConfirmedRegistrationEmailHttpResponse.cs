using FuDever.Application.Features.Auth.ChangingPassword;
using FuDever.Application.Features.Auth.ConfirmUserRegistrationConfirmedEmail;
using FuDever.WebApi.HttpResponseMapper.Auth.ConfirmUserRegistrationConfirmedEmail.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.ConfirmUserRegistrationConfirmedEmail;

/// <summary>
///     Confirm user registration confirmed email
///     response status code -
///     - user has confirmed the registration
///     email http response.
/// </summary>
internal sealed class UserHasConfirmedRegistrationEmailHttpResponse
    : ConfirmUserRegistrationConfirmedEmailHttpResponse
{
    internal UserHasConfirmedRegistrationEmailHttpResponse(
        ConfirmUserRegistrationConfirmedEmailResponse response
    )
    {
        HttpCode = StatusCodes.Status200OK;
        AppCode = response.StatusCode.ToAppCode();
        Body = response.ResponseBodyAsHtml;
    }
}
