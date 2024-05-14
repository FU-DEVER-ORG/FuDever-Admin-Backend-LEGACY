using FuDever.Application.Features.Auth.RequestForgotPassword;
using FuDever.WebApi.HttpResponseMapper.Auth.RequestForgotPassword.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.RequestForgotPassword;

/// <summary>
///     Request Forgot password response status code
///     - input validation fail http
///     response.
/// </summary>
internal sealed class InputValidationFailHttpResponse : RequestForgotPasswordHttpResponse
{
    internal InputValidationFailHttpResponse(RequestForgotPasswordResponse response)
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Input validation fail. Please check your inputs and try again."];
    }
}
