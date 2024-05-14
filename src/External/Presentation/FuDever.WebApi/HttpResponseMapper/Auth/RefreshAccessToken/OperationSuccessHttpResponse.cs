using FuDever.Application.Features.Auth.RefreshAccessToken;
using FuDever.WebApi.HttpResponseMapper.Auth.RefreshAccessToken.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.RefreshAccessToken;

/// <summary>
///     Refresh access token response status code
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : RefreshAccessTokenHttpResponse
{
    internal OperationSuccessHttpResponse(RefreshAccessTokenResponse response)
    {
        HttpCode = StatusCodes.Status200OK;
        AppCode = response.StatusCode.ToAppCode();
        Body = response.ResponseBody;
    }
}
