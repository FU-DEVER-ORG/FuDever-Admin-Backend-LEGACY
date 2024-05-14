using FuDever.Application.Features.Auth.ResendUserRegistrationConfirmedEmail;
using FuDever.WebApi.HttpResponseMapper.Auth.ResendUserRegistrationConfirmedEmail.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.ResendUserRegistrationConfirmedEmail;

/// <summary>
///     Resend user registration confirmed email
///     response status code -
///     - input validation fail http
///     response.
/// </summary>
internal sealed class InputValidationFailHttpResponse
    : ResendUserRegistrationConfirmedEmailHttpResponse
{
    internal InputValidationFailHttpResponse(ResendUserRegistrationConfirmedEmailResponse response)
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Input validation fail. Please check your inputs and try again."];
    }
}
