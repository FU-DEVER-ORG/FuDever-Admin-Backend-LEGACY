using FuDever.Application.Features.Auth.RefreshAccessToken;
using FuDever.WebApi.HttpResponseMapper.Auth.RefreshAccessToken.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.RefreshAccessToken;

/// <summary>
///     Refresh access token response status code
///     - un authorized http response.
/// </summary>
internal sealed class UnAuthorizedHttpResponse : RefreshAccessTokenHttpResponse
{
    internal UnAuthorizedHttpResponse(RefreshAccessTokenResponse response)
    {
        HttpCode = StatusCodes.Status401Unauthorized;
        AppCode = response.StatusCode.ToAppCode();
    }
}
