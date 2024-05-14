using FuDever.Application.Features.Auth.ChangingPassword;
using FuDever.WebApi.HttpResponseMapper.Auth.ChangingPassword.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.ChangingPassword;

/// <summary>
///     Changing password response status code
///     - input validation fail http
///     response.
/// </summary>
internal sealed class InputValidationFailHttpResponse : ChangingPasswordHttpResponse
{
    internal InputValidationFailHttpResponse(ChangingPasswordResponse response)
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Input validation fail. Please check your inputs and try again."];
    }
}
