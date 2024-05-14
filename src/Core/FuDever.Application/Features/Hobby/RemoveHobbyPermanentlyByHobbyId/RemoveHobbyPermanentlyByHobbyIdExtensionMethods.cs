namespace FuDever.Application.Features.Hobby.RemoveHobbyPermanentlyByHobbyId;

/// <summary>
///     Extension method for removing hobby
///     permanently by hobby id feature.
/// </summary>
public static class RemoveHobbyPermanentlyByHobbyIdExtensionMethods
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
        this RemoveHobbyPermanentlyByHobbyIdResponseStatusCode statusCode
    )
    {
        return $"{nameof(Hobby)}.{nameof(RemoveHobbyPermanentlyByHobbyId)}.{(int)statusCode}";
    }
}
