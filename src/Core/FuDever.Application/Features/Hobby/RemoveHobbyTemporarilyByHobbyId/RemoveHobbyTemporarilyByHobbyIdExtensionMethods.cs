namespace FuDever.Application.Features.Hobby.RemoveHobbyTemporarilyByHobbyId;

/// <summary>
///     Extension method for removing hobby
///     temporarily by hobby id feature.
/// </summary>
public static class RemoveHobbyTemporarilyByHobbyIdExtensionMethods
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
        this RemoveHobbyTemporarilyByHobbyIdResponseStatusCode statusCode
    )
    {
        return $"{nameof(Hobby)}.{nameof(RemoveHobbyTemporarilyByHobbyId)}.{(int)statusCode}";
    }
}
