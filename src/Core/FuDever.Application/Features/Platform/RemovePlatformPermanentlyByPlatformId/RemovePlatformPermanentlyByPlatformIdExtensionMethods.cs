namespace FuDever.Application.Features.Platform.RemovePlatformPermanentlyByPlatformId;

/// <summary>
///     Extension method remove platform
///     permanently by platform id feature.
/// </summary>
public static class RemovePlatformPermanentlyByPlatformIdExtensionMethods
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
    public static string ToAppCode(
        this RemovePlatformPermanentlyByPlatformIdResponseStatusCode statusCode
    )
    {
        return $"{nameof(Major)}.{nameof(RemovePlatformPermanentlyByPlatformId)}.{(int)statusCode}";
    }
}
