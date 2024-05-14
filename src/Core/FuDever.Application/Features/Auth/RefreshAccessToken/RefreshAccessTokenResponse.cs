namespace FuDever.Application.Features.Auth.RefreshAccessToken;

/// <summary>
///     Refresh access token response.
/// </summary>
public sealed class RefreshAccessTokenResponse
{
    public RefreshAccessTokenResponseStatusCode StatusCode { get; init; }

    public Body ResponseBody { get; init; }

    public sealed class Body
    {
        public string AccessToken { get; init; }

        public string RefreshToken { get; init; }
    }
}
