using FuDever.Application.Features.Auth.RefreshAccessToken;
using FuDever.WebApi.HttpResponseMapper.Auth.RefreshAccessToken.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.RefreshAccessToken;

/// <summary>
///     Refresh access token response status code -
///     database operation fail http response.
/// </summary>
internal sealed class DatabaseOperationFailHttpResponse : RefreshAccessTokenHttpResponse
{
    internal DatabaseOperationFailHttpResponse(RefreshAccessTokenResponse response)
    {
        HttpCode = StatusCodes.Status500InternalServerError;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Server error !!!"];
    }
}
