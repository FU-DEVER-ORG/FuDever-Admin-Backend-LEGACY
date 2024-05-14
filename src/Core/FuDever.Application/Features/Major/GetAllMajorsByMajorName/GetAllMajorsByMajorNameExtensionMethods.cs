namespace FuDever.Application.Features.Major.GetAllMajorsByMajorName;

/// <summary>
///     Extension method for get all
///     major by major name feature.
/// </summary>
public static class GetAllMajorsByMajorNameExtensionMethods
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
    public static string ToAppCode(this GetAllMajorsByMajorNameResponseStatusCode statusCode)
    {
        return $"{nameof(Major)}.{nameof(GetAllMajorsByMajorName)}.{(int)statusCode}";
    }
}
