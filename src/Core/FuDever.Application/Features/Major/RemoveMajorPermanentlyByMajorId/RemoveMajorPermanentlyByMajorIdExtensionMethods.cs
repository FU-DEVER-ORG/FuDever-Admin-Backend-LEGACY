namespace FuDever.Application.Features.Major.RemoveMajorPermanentlyByMajorId;

/// <summary>
///     Extension method for remove major
///     permanently by major Id feature.
/// </summary>
public static class RemoveMajorPermanentlyByMajorIdExtensionMethods
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
        this RemoveMajorPermanentlyByMajorIdResponseStatusCode statusCode
    )
    {
        return $"{nameof(Major)}.{nameof(RemoveMajorPermanentlyByMajorId)}.{(int)statusCode}";
    }
}
