using FuDever.Application.Features.Auth.RequestForgotPassword;
using FuDever.WebApi.HttpResponseMapper.Auth.RequestForgotPassword.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.RequestForgotPassword;

/// <summary>
///     Request Forgot password response status code
///     - user is not found http response.
/// </summary>
internal sealed class UserIsNotFoundHttpResponse : RequestForgotPasswordHttpResponse
{
    internal UserIsNotFoundHttpResponse(
        RequestForgotPasswordRequest request,
        RequestForgotPasswordResponse response
    )
    {
        HttpCode = StatusCodes.Status404NotFound;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"User with username = {request.Username} is not found."];
    }
}
