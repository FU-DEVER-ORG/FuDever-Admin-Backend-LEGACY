using FuDever.Application.Features.Auth.RequestForgotPassword;
using FuDever.WebApi.HttpResponseMapper.Auth.RequestForgotPassword.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.RequestForgotPassword;

/// <summary>
///     Request Forgot password response status code - database operation
///     fail http response.
/// </summary>
internal sealed class DatabaseOperationFailHttpResponse : RequestForgotPasswordHttpResponse
{
    internal DatabaseOperationFailHttpResponse(RequestForgotPasswordResponse response)
    {
        HttpCode = StatusCodes.Status500InternalServerError;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Server error !!!"];
    }
}
