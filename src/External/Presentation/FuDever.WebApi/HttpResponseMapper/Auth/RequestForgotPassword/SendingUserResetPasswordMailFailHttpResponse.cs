using FuDever.Application.Features.Auth.RequestForgotPassword;
using FuDever.WebApi.HttpResponseMapper.Auth.RequestForgotPassword.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.RequestForgotPassword;

/// <summary>
///     Request forgot password response status code
///     - sending user confirmation mail fail
///     http response.
/// </summary>
internal sealed class SendingUserResetPasswordMailFailHttpResponse
    : RequestForgotPasswordHttpResponse
{
    internal SendingUserResetPasswordMailFailHttpResponse(RequestForgotPasswordResponse response)
    {
        HttpCode = StatusCodes.Status500InternalServerError;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages =
        [
            "Sending user reset password email fail !!",
            "Please contact admin for support."
        ];
    }
}
