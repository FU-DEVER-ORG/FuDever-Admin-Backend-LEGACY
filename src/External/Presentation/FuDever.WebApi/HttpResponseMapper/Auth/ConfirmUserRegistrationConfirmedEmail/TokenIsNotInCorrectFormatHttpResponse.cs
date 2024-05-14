using FuDever.Application.Features.Auth.ChangingPassword;
using FuDever.Application.Features.Auth.ConfirmUserRegistrationConfirmedEmail;
using FuDever.WebApi.HttpResponseMapper.Auth.ConfirmUserRegistrationConfirmedEmail.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.ConfirmUserRegistrationConfirmedEmail;

/// <summary>
///     Confirm user registration confirmed email
///     response status code -
///     - token is not in correct
///     format http response.
/// </summary>
internal sealed class TokenIsNotInCorrectFormatHttpResponse
    : ConfirmUserRegistrationConfirmedEmailHttpResponse
{
    internal TokenIsNotInCorrectFormatHttpResponse(
        ConfirmUserRegistrationConfirmedEmailResponse response
    )
    {
        HttpCode = StatusCodes.Status200OK;
        AppCode = response.StatusCode.ToAppCode();
        Body = response.ResponseBodyAsHtml;
    }
}
