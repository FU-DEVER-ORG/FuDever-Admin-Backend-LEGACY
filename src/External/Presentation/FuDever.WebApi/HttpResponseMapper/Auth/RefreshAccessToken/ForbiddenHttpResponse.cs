using FuDever.Application.Features.Auth.RefreshAccessToken;
using FuDever.WebApi.HttpResponseMapper.Auth.RefreshAccessToken.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.RefreshAccessToken;

/// <summary>
///     Refresh access token response status code
///     - forbidden http response.
/// </summary>
internal sealed class ForbiddenHttpResponse : RefreshAccessTokenHttpResponse
{
    internal ForbiddenHttpResponse(RefreshAccessTokenResponse response)
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
    }
}
