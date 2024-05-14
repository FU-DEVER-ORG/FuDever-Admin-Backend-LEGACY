namespace FuDever.Application.Features.Major.CreateMajor;

/// <summary>
///     Extension method for create major feature.
/// </summary>
public static class CreateMajorExtensionMethods
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
    public static string ToAppCode(this CreateMajorResponseStatusCode statusCode)
    {
        return $"{nameof(Major)}.{nameof(CreateMajor)}.{(int)statusCode}";
    }
}
