namespace FuDever.Application.Features.Major.GetAllMajors;

/// <summary>
///     Extension method for get all major feature.
/// </summary>
public static class GetAllMajorsExtensionMethods
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
    public static string ToAppCode(this GetAllMajorsResponseStatusCode statusCode)
    {
        return $"{nameof(Major)}.{nameof(GetAllMajors)}.{(int)statusCode}";
    }
}
