using FuDever.Application.Features.Auth.ChangingPassword;
using FuDever.WebApi.HttpResponseMapper.Auth.ChangingPassword.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.ChangingPassword;

/// <summary>
///     Changing password response status code
///     - reset password token is not found http
///     response.
/// </summary>
internal sealed class ResetPasswordTokenIsNotFoundHttpResponse : ChangingPasswordHttpResponse
{
    internal ResetPasswordTokenIsNotFoundHttpResponse(ChangingPasswordResponse response)
    {
        HttpCode = StatusCodes.Status404NotFound;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["User reset password token is not found."];
    }
}
