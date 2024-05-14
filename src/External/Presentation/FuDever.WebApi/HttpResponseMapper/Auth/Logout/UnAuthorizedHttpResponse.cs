using FuDever.Application.Features.Auth.Logout;
using FuDever.WebApi.HttpResponseMapper.Auth.Logout.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.Logout;

/// <summary>
///     Logout response status code
///     - un authorized http response.
/// </summary>
internal sealed class UnAuthorizedHttpResponse : LogoutHttpResponse
{
    internal UnAuthorizedHttpResponse(LogoutResponse response)
    {
        HttpCode = StatusCodes.Status401Unauthorized;
        AppCode = response.StatusCode.ToAppCode();
    }
}
