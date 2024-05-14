namespace FuDever.Application.Features.Platform.GetAllPlatforms;

/// <summary>
///     Extension method for get all platforms feature.
/// </summary>
public static class GetAllPlatformsExtensionMethods
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
    public static string ToAppCode(this GetAllPlatformsResponseStatusCode statusCode)
    {
        return $"{nameof(Major)}.{nameof(GetAllPlatforms)}.{(int)statusCode}";
    }
}
