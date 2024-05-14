namespace FuDever.Application.Features.Hobby.RestoreHobbyByHobbyId;

/// <summary>
///     Extension method for restore hobby
///     by hobby id feature.
/// </summary>
public static class RestoreHobbyByHobbyIdExtensionMethods
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
    public static string ToAppCode(this RestoreHobbyByHobbyIdResponseStatusCode statusCode)
    {
        return $"{nameof(Hobby)}.{nameof(RestoreHobbyByHobbyId)}.{(int)statusCode}";
    }
}
