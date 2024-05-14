namespace FuDever.Application.Features.Hobby.CreateHobby;

/// <summary>
///     Extension method for create hobby feature.
/// </summary>
public static class CreateHobbyExtensionMethods
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
    public static string ToAppCode(this CreateHobbyResponseStatusCode statusCode)
    {
        return $"{nameof(Hobby)}.{nameof(CreateHobby)}.{(int)statusCode}";
    }
}
