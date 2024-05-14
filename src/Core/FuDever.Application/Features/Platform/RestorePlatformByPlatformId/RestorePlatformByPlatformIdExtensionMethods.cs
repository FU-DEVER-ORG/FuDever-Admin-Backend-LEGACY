namespace FuDever.Application.Features.Platform.RestorePlatformByPlatformId;

/// <summary>
///     Extension method for restore platform
///     by platform id feature.
/// </summary>
public static class RestorePlatformByPlatformIdExtensionMethods
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
    public static string ToAppCode(this RestorePlatformByPlatformIdResponseStatusCode statusCode)
    {
        return $"{nameof(Major)}.{nameof(RestorePlatformByPlatformId)}.{(int)statusCode}";
    }
}
