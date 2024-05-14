using FuDever.Application.Features.Auth.ChangingPassword;
using FuDever.Application.Features.Auth.ConfirmUserRegistrationConfirmedEmail;
using FuDever.WebApi.HttpResponseMapper.Auth.ConfirmUserRegistrationConfirmedEmail.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.ConfirmUserRegistrationConfirmedEmail;

/// <summary>
///     Confirm user registration confirmeds email
///     response status code -
///     database operation fail http response.
/// </summary>
internal sealed class DatabaseOperationFailHttpResponse
    : ConfirmUserRegistrationConfirmedEmailHttpResponse
{
    internal DatabaseOperationFailHttpResponse(
        ConfirmUserRegistrationConfirmedEmailResponse response
    )
    {
        HttpCode = StatusCodes.Status200OK;
        AppCode = response.StatusCode.ToAppCode();
        Body = response.ResponseBodyAsHtml;
    }
}
