namespace FuDever.Application.Features.Platform.CreatePlatform;

/// <summary>
///     Extension method for create platform feature.
/// </summary>
public static class CreatePlatformExtensionMethods
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
    public static string ToAppCode(this CreatePlatformResponseStatusCode statusCode)
    {
        return $"{nameof(Major)}.{nameof(CreatePlatform)}.{(int)statusCode}";
    }
}
