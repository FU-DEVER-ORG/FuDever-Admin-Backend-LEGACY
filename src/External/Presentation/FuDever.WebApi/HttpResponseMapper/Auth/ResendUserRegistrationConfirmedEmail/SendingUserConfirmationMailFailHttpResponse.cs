using FuDever.Application.Features.Auth.ResendUserRegistrationConfirmedEmail;
using FuDever.WebApi.HttpResponseMapper.Auth.ResendUserRegistrationConfirmedEmail.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.ResendUserRegistrationConfirmedEmail;

/// <summary>
///     Confirm user registration confirmed email
///     response status code
///     - sending user confirmation mail fail
///     http response.
/// </summary>
internal sealed class SendingUserConfirmationMailFailHttpResponse
    : ResendUserRegistrationConfirmedEmailHttpResponse
{
    internal SendingUserConfirmationMailFailHttpResponse(
        ResendUserRegistrationConfirmedEmailResponse response
    )
    {
        HttpCode = StatusCodes.Status500InternalServerError;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Sending confirmation email fail !!", "Please contact admin for support."];
    }
}
