using FuDever.Application.Features.Auth.RefreshAccessToken;
using FuDever.WebApi.HttpResponseMapper.Auth.RefreshAccessToken.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.RefreshAccessToken;

/// <summary>
///     Refresh access token response status code
///     - refresh token is not found http response.
/// </summary>
internal sealed class RefreshTokenIsNotFound : RefreshAccessTokenHttpResponse
{
    internal RefreshTokenIsNotFound(RefreshAccessTokenResponse response)
    {
        HttpCode = StatusCodes.Status404NotFound;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Refresh token is not found. Please check your inputs and try again."];
    }
}
