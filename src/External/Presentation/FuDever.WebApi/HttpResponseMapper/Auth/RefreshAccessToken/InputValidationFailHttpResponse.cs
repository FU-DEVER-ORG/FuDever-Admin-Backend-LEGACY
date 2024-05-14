using FuDever.Application.Features.Auth.RefreshAccessToken;
using FuDever.WebApi.HttpResponseMapper.Auth.RefreshAccessToken.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.RefreshAccessToken;

/// <summary>
///     Refresh access token
///     response status code -
///     - input validation fail http
///     response.
/// </summary>
internal sealed class InputValidationFailHttpResponse : RefreshAccessTokenHttpResponse
{
    internal InputValidationFailHttpResponse(RefreshAccessTokenResponse response)
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Input validation fail. Please check your inputs and try again."];
    }
}
