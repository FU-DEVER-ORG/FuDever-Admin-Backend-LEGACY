namespace FuDever.Application.Features.Major.UpdateMajorByMajorId;

/// <summary>
///     Extension method for update major by
///     major Id feature.
/// </summary>
public static class UpdateMajorByMajorIdExtensionMethods
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
    public static string ToAppCode(this UpdateMajorByMajorIdResponseStatusCode statusCode)
    {
        return $"{nameof(Major)}.{nameof(UpdateMajorByMajorId)}.{(int)statusCode}";
    }
}
