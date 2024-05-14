namespace FuDever.Application.Features.Platform.GetAllTemporarilyRemovedPlatforms;

/// <summary>
///     Extension method for get all temporarily
///     removed platforms feature.
/// </summary>
public static class GetAllTemporarilyRemovedPlatformsExtensionMethods
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
        this GetAllTemporarilyRemovedPlatformsResponseStatusCode statusCode
    )
    {
        return $"{nameof(Major)}.{nameof(GetAllTemporarilyRemovedPlatforms)}.{(int)statusCode}";
    }
}
