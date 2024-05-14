namespace FuDever.Application.Features.Auth.RefreshAccessToken;

/// <summary>
///     Refresh access token extension methods.
/// </summary>
public static class RefreshAccessTokenExtensionMethods
{
    /// <summary>
    ///     Mapping from feature response status code to
    ///     app code.
    /// </summary>
    /// <param name="statusCode">
    ///     Feature response status code
    /// </param>
    /// <returns>
    ///     New app code.
    /// </returns>
    public static string ToAppCode(this RefreshAccessTokenResponseStatusCode statusCode)
    {
        return $"{nameof(Auth)}.{nameof(RefreshAccessToken)}.{(int)statusCode}";
    }
}
