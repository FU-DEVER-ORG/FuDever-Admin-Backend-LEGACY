using FuDever.Application.Features.Auth.ResendUserRegistrationConfirmedEmail;
using FuDever.WebApi.HttpResponseMapper.Auth.ResendUserRegistrationConfirmedEmail.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.ResendUserRegistrationConfirmedEmail;

/// <summary>
///     Confirm user registration confirmed email
///     response status code -
///     - user is not found http response.
/// </summary>
internal sealed class UserIsNotFoundHttpResponse : ResendUserRegistrationConfirmedEmailHttpResponse
{
    internal UserIsNotFoundHttpResponse(
        ResendUserRegistrationConfirmedEmailRequest request,
        ResendUserRegistrationConfirmedEmailResponse response
    )
    {
        HttpCode = StatusCodes.Status404NotFound;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"User with username = {request.Username} is not found."];
    }
}
