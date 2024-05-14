namespace FuDever.Application.Features.Auth.Logout;

/// <summary>
///     Extension method for logout feature.
/// </summary>
public static class LogoutExtensionMethods
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
    public static string ToAppCode(this LogoutResponseStatusCode statusCode)
    {
        return $"{nameof(Auth)}.{nameof(Logout)}.{(int)statusCode}";
    }
}
