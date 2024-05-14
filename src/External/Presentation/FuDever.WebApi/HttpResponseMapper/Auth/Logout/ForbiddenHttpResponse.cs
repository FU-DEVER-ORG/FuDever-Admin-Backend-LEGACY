using FuDever.Application.Features.Auth.Logout;
using FuDever.WebApi.HttpResponseMapper.Auth.Logout.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.Logout;

/// <summary>
///     Logout response status code
///     - forbidden http response.
/// </summary>
internal sealed class ForbiddenHttpResponse : LogoutHttpResponse
{
    internal ForbiddenHttpResponse(LogoutResponse response)
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
    }
}
