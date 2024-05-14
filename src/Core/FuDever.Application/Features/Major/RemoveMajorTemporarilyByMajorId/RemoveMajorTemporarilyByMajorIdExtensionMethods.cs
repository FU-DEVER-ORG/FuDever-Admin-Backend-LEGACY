namespace FuDever.Application.Features.Major.RemoveMajorTemporarilyByMajorId;

/// <summary>
///     Extension method for remove major
///     temporarily by major Id feature.
/// </summary>
public static class RemoveMajorTemporarilyByMajorIdExtensionMethods
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
        this RemoveMajorTemporarilyByMajorIdResponseStatusCode statusCode
    )
    {
        return $"{nameof(Major)}.{nameof(RemoveMajorTemporarilyByMajorId)}.{(int)statusCode}";
    }
}
