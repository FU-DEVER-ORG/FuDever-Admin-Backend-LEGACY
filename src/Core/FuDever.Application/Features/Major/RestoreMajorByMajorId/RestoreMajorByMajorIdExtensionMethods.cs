namespace FuDever.Application.Features.Major.RestoreMajorByMajorId;

/// <summary>
///     Extension method for restore major by
///     major Id feature.
/// </summary>
public static class RestoreMajorByMajorIdExtensionMethods
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
    public static string ToAppCode(this RestoreMajorByMajorIdResponseStatusCode statusCode)
    {
        return $"{nameof(Major)}.{nameof(RestoreMajorByMajorId)}.{(int)statusCode}";
    }
}
