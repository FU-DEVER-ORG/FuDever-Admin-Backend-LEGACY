using FuDever.Application.Features.Auth.ChangingPassword;
using FuDever.WebApi.HttpResponseMapper.Auth.ChangingPassword.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.ChangingPassword;

/// <summary>
///     Changing password response status code
///     - new user password is not valid
///     http response.
/// </summary>
internal sealed class NewPasswordIsNotValidHttpResponse : ChangingPasswordHttpResponse
{
    internal NewPasswordIsNotValidHttpResponse(ChangingPasswordResponse response)
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["New user password is not valid."];
    }
}
