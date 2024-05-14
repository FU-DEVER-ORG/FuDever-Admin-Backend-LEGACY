namespace FuDever.Application.Features.Platform.RemovePlatformTemporarilyByPlatformId;

/// <summary>
///     Extension method remove platform
///     temporarily by platform id feature.
/// </summary>
public static class RemovePlatformTemporarilyByPlatformIdExtensionMethods
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
        this RemovePlatformTemporarilyByPlatformIdResponseStatusCode statusCode
    )
    {
        return $"{nameof(Major)}.{nameof(RemovePlatformTemporarilyByPlatformId)}.{(int)statusCode}";
    }
}
