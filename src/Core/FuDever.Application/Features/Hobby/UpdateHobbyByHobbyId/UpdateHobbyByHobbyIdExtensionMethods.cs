namespace FuDever.Application.Features.Hobby.UpdateHobbyByHobbyId;

/// <summary>
///     Extension method for update hobby
///     by hobby id feature.
/// </summary>
public static class UpdateHobbyByHobbyIdExtensionMethods
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
    public static string ToAppCode(this UpdateHobbyByHobbyIdResponseStatusCode statusCode)
    {
        return $"{nameof(Hobby)}.{nameof(UpdateHobbyByHobbyId)}.{(int)statusCode}";
    }
}
