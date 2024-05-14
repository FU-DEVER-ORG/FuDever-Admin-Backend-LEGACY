using FuDever.Application.Features.Auth.ChangingPassword;
using FuDever.WebApi.HttpResponseMapper.Auth.ChangingPassword.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.ChangingPassword;

/// <summary>
///     Changing password response status code
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : ChangingPasswordHttpResponse
{
    internal OperationSuccessHttpResponse(ChangingPasswordResponse response)
    {
        HttpCode = StatusCodes.Status200OK;
        AppCode = response.StatusCode.ToAppCode();
    }
}
