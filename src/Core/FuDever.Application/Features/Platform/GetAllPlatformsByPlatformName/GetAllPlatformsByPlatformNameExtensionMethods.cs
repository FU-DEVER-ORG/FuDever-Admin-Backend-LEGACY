namespace FuDever.Application.Features.Platform.GetAllPlatformsByPlatformName;

/// <summary>
///     Extension method for get all platforms
///     by platform name feature.
/// </summary>
public static class GetAllPlatformsByPlatformNameExtensionMethods
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
    public static string ToAppCode(this GetAllPlatformsByPlatformNameResponseStatusCode statusCode)
    {
        return $"{nameof(Major)}.{nameof(GetAllPlatformsByPlatformName)}.{(int)statusCode}";
    }
}
