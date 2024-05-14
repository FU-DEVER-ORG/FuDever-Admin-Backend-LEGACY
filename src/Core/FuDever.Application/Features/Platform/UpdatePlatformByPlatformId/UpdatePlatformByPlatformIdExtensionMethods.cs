namespace FuDever.Application.Features.Platform.UpdatePlatformByPlatformId;

/// <summary>
///     Extension method for  update
///     platform by platform id feature.
/// </summary>
public static class UpdatePlatformByPlatformIdExtensionMethods
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
    public static string ToAppCode(this UpdatePlatformByPlatformIdResponseStatusCode statusCode)
    {
        return $"{nameof(Major)}.{nameof(UpdatePlatformByPlatformId)}.{(int)statusCode}";
    }
}
