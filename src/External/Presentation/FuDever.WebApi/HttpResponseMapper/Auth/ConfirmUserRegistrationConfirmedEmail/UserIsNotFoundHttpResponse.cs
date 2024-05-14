using FuDever.Application.Features.Auth.ChangingPassword;
using FuDever.Application.Features.Auth.ConfirmUserRegistrationConfirmedEmail;
using FuDever.WebApi.HttpResponseMapper.Auth.ConfirmUserRegistrationConfirmedEmail.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.ConfirmUserRegistrationConfirmedEmail;

/// <summary>
///     Confirm user registration confirmed email
///     response status code
///     - user is not found http response.
/// </summary>
internal sealed class UserIsNotFoundHttpResponse : ConfirmUserRegistrationConfirmedEmailHttpResponse
{
    internal UserIsNotFoundHttpResponse(ConfirmUserRegistrationConfirmedEmailResponse response)
    {
        HttpCode = StatusCodes.Status404NotFound;
        AppCode = response.StatusCode.ToAppCode();
        Body = response.ResponseBodyAsHtml;
        ErrorMessages = ["Not found the user with the token."];
    }
}
