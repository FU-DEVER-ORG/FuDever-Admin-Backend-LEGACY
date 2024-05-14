using FuDever.Application.Features.Auth.RequestForgotPassword;
using FuDever.WebApi.HttpResponseMapper.Auth.RequestForgotPassword.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.RequestForgotPassword;

/// <summary>
///     Request Forgot password response status code
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : RequestForgotPasswordHttpResponse
{
    internal OperationSuccessHttpResponse(RequestForgotPasswordResponse response)
    {
        HttpCode = StatusCodes.Status200OK;
        AppCode = response.StatusCode.ToAppCode();
    }
}
