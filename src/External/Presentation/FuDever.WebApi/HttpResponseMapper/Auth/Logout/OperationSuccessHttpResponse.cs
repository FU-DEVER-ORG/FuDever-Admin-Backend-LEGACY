using FuDever.Application.Features.Auth.Logout;
using FuDever.WebApi.HttpResponseMapper.Auth.Logout.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.Logout;

/// <summary>
///     Logout response status code
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : LogoutHttpResponse
{
    internal OperationSuccessHttpResponse(LogoutResponse response)
    {
        HttpCode = StatusCodes.Status200OK;
        AppCode = response.StatusCode.ToAppCode();
    }
}
